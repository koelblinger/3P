﻿#region header
// ========================================================================
// Copyright (c) 2018 - Julien Caillon (julien.caillon@gmail.com)
// This file (ProCodeFormat.cs) is part of 3P.
// 
// 3P is a free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// 3P is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with 3P. If not, see <http://www.gnu.org/licenses/>.
// ========================================================================
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3PA.Lib;
using _3PA.MainFeatures.Parser.Pro;
using _3PA.MainFeatures.Parser.Pro.Parse;
using _3PA.NppCore;

namespace _3PA.MainFeatures.Pro {

    internal static class ProCodeFormat {

        public static Dictionary<int, LineInfo> GetIndentation(Dictionary<int, ParsedLineInfo> lineInfos) {

            var output = new Dictionary<int, LineInfo>();

            foreach (var kpv in lineInfos) {

                int curLine = kpv.Key;
                ParsedLineInfo lineInfo = kpv.Value;

                // compute current depth
                // -1 because we always have a block that represents the current file
                var depth = -1;
                var iloop = 0;
                while (iloop < lineInfo.BlockStack.Count) {
                    var block = lineInfo.BlockStack.ElementAt(iloop);
                    iloop++;

                    // do not indent &ANALYZE-SUSPEND blocks
                    if (block.ScopeType == ParsedScopeType.PreProcAnalyzeBlock) {
                        if (block.Line == curLine - 1) {
                            if (!output.ContainsKey(block.Line)) {
                                output.Add(block.Line, new LineInfo(0, 0));
                            }
                            if (block.EndBlockLine > block.Line && !output.ContainsKey(block.EndBlockLine)) {
                                output.Add(block.EndBlockLine, new LineInfo(0, 0));
                            }
                        }
                        continue;
                    }

                    // do not indent &IF DEFINED(EXCLUDE-btinitalto) = 0 &THEN
                    var preprocIf = block as ParsedScopePreProcIfBlock;
                    if (preprocIf != null && preprocIf.EvaluatedExpression.StartsWith("DEFINED(EXCLUDE-")) {
                        continue;
                    }

                    var onBlock = block as ParsedOnStatement;
                    if (onBlock != null && curLine <= onBlock.TriggerBlock.Line) {
                        // ON CHOOSE OF bt_profileRename IN FRAME DEFAULT-FRAME
                        // DO: <- this would be indented if not for this rule
                        continue;
                    }
                        
                    // only the lines AFTER the start of the block should be indent
                    if (curLine > block.Line) {
                        depth++;
                    }
                }
                depth = Math.Max(depth, 0);
                
                    
                // other lines of the statement
                if (curLine > lineInfo.StatementStartLine) {

                    // first line of the statement
                    if (!output.ContainsKey(lineInfo.StatementStartLine)) {
                        output.Add(lineInfo.StatementStartLine, new LineInfo(depth, 0));
                    }

                    var extraStatementDepth = 0;
                    var block = lineInfo.BlockStack.Peek();
                    var blockOneStatementIndent = block as ParsedScopeOneStatementIndentBlock;
                    if (blockOneStatementIndent != null && blockOneStatementIndent.LineOfNextWord > blockOneStatementIndent.Line && curLine > blockOneStatementIndent.Line + 1) {
                        // IF TRUE THEN
                        //     ASSIGN
                        //         lc_ "ok". <- this would NOT be indented if not for this rule
                        extraStatementDepth = 1;
                    } else if (blockOneStatementIndent == null && curLine > block.Line + 1 && !(block is ParsedOnStatement)) {
                        // DEFINE VARIABLE
                        //     lc_fuck AS CHARACTER NO-UNDO.  <- this would NOT be indented if not for this rule
                        extraStatementDepth = 1;
                    }

                    // fill missing info on the lines of the statement
                    for (int i = lineInfo.StatementStartLine + 1; i <= curLine; i++) {
                        if (!output.ContainsKey(i)) {
                            output.Add(i, new LineInfo(depth, extraStatementDepth));
                        } else if (extraStatementDepth == 0 && output[i].ExtraStatementDepth > 0) {
                            // at some point for this statement we added an extra indent but now tis line is at extra = 0, restore the previous lines to 0 aswell
                            // WHEN 1 OR 
                            // WHEN 3 OR <- this would be indented if not for this rule
                            // WHEN 2 THEN
                            //     MESSAGE "ok".
                            output[i].ExtraStatementDepth = 0;
                        }
                    }
                } else if (!output.ContainsKey(curLine)) {
                    output.Add(curLine, new LineInfo(depth, 0));
                }
            }

            return output;
        }

        /// <summary>
        /// Tries to re-indent the code of the whole document
        /// </summary>
        public static void CorrectCodeIndentation() {

            // handle spam (1s min between 2 indent)
            if (Utils.IsSpamming("CorrectCodeIndentation", 1000))
                return;

            var parser = new Parser.Pro.Parse.Parser(Sci.Text, Npp.CurrentFileInfo.Path, null, false);

            // in case of an incorrect document, warn the user
            var parserErrors = parser.ParseErrorsInHtml;
            if (!string.IsNullOrEmpty(parserErrors)) {
                if (UserCommunication.Message("The internal parser of 3P has found inconsistencies in your document :<br>" + parserErrors + "<br>You can still try to format your code but the result is not guaranteed (worst case scenario you can press CTRL+Z).<br>If the code compiles successfully and the document is incorrectly formatted, please make sure to create an issue on the project's github and (if possible) include the incriminating code so i can fix this problem : <br>" + Config.UrlIssues.ToHtmlLink() + "<br><br>Please confirm that you want to proceed", MessageImg.MsgQuestion, "Correct indentation", "Problems spotted", new List<string> { "Continue", "Abort" }) != 0)
                    return;
            }
            
            // start indenting
            Sci.BeginUndoAction();

            var indentStartLine = Sci.LineFromPosition(Sci.SelectionStart);
            var indentEndLine = Sci.LineFromPosition(Sci.SelectionEnd);
            
            var indentWidth = Sci.TabWidth;
            var i = 0;
            var dic = GetIndentation(parser.LineInfo);
            while (dic.ContainsKey(i)) {
                if (indentStartLine == indentEndLine || (i >= indentStartLine && i <= indentEndLine)) {
                    var line = Sci.GetLine(i);
                    line.Indentation = (dic[i].BlockDepth + dic[i].ExtraStatementDepth) * indentWidth;
                }
                i++;
            }
            Sci.EndUndoAction();
        }

        /// <summary>
        /// Returns true if the document starts with & ANALYZE-SUSPEND _VERSION-NUMBER
        /// which indicates that it will be opened as a structured proc in the appbuilder
        /// </summary>
        /// <returns></returns>
        public static bool IsCurrentFileFromAppBuilder {
            get {
                if (!Sci.GetLine(0).LineText.Trim().StartsWith("&ANALYZE-SUSPEND _VERSION-NUMBER", StringComparison.CurrentCultureIgnoreCase))
                    return false;
                return true;
            }
        }

        /// <summary>
        /// Allows to clear the appbuilder markup from a given string
        /// </summary>
        public static string StripAppBuilderMarkup(string inputSnippet) {
            // consist in suppressing the lines starting with :
            // &ANALYZE-SUSPEND
            // &ANALYZE-RESUME
            // /* _UIB-CODE-BLOCK-END */
            // and, for this method only, also strips :
            // &IF DEFINED(EXCLUDE-&{name}) = 0 &THEN
            // &ENDIF
            var outputSnippet = new StringBuilder();
            string line;
            using (StringReader reader = new StringReader(inputSnippet)) {
                while ((line = reader.ReadLine()) != null) {
                    if (line.Length == 0 || (line[0] != '&' && !line.Equals(@"/* _UIB-CODE-BLOCK-END */")))
                        outputSnippet.AppendLine(line);
                }
            }
            return outputSnippet.ToString();
        }

        private static HashSet<string> _displayParserErrorsIgnoredFiles = new HashSet<string>();

        /// <summary>
        /// Check the validity of a progress code in the point of view of the appbuilder (make sure it can be opened within the appbuilder)
        /// </summary>
        public static void DisplayParserErrors(bool silent = false) {
            if (Npp.CurrentFileInfo.IsProgress && !_displayParserErrorsIgnoredFiles.Contains(Npp.CurrentFileInfo.Path)) {
                Task.Factory.StartNew(() => {
                    var currentFilePath = Npp.CurrentFileInfo.Path;

                    UserCommunication.CloseUniqueNotif("DisplayParserErrors" + currentFilePath);

                    var message = new StringBuilder();
                    message.Append("The analyzed file was :<br>" + currentFilePath.ToHtmlLink() + "<br>");

                    var parser = new Parser.Pro.Parse.Parser(Sci.Text, currentFilePath, null, false);

                    var parserErrors = parser.ParseErrorsInHtml;
                    if (!string.IsNullOrEmpty(parserErrors)) {
                        message.Append("<br>The parser found syntax errors.<br>You should consider solving those issues in the given order :<br>");
                        message.Append(parserErrors);
                    }

                    var blockTooLong = new StringBuilder();
                    foreach (var scope in parser.ParsedItemsList.Where(item => item is ParsedImplementation || item is ParsedProcedure || item is ParsedOnStatement).Cast<ParsedScopeBlock>()) {
                        if (CheckForTooMuchChar(scope)) {
                            blockTooLong.AppendLine("<div>");
                            blockTooLong.AppendLine(" - " + (scope.FilePath + "|" + scope.Line).ToHtmlLink("Line " + (scope.Line + 1) + " : <b>" + scope.Name + "</b>") + " (" + NbExtraCharBetweenLines(scope.Line, scope.EndBlockLine) + " extra chars)");
                            blockTooLong.AppendLine("</div>");
                        }
                    }
                    if (blockTooLong.Length > 0) {
                        message.Append("<br>This file is currently unreadable in the AppBuilder.<br>The following blocks contain more characters than the max limit (" + Config.Instance.GlobalMaxNbCharInBlock + " characters) :<br>");
                        message.Append(blockTooLong);
                        message.Append("<br><i>To prevent this, reduce the number of characters in the above blocks.<br>Deleting dead code and trimming spaces is a good place to start!</i>");
                    }

                    // no errors
                    var noProb = blockTooLong.Length == 0 && string.IsNullOrEmpty(parserErrors);
                    if (noProb) {
                        if (silent)
                            return;
                        message.Append("No problems found!");
                    } else {
                        if (silent)
                            message.Append("<br><br>" + "disable".ToHtmlLink("Click here to disable the automatic check for this file"));
                    }

                    UserCommunication.NotifyUnique("DisplayParserErrors" + currentFilePath, message.ToString(), noProb ? MessageImg.MsgOk : MessageImg.MsgWarning, "Check code validity", "Analysis results", args => {
                        if (args.Link.Equals("disable")) {
                            args.Handled = true;
                            UserCommunication.CloseUniqueNotif("DisplayParserErrors" + currentFilePath);
                            if (!_displayParserErrorsIgnoredFiles.Contains(currentFilePath))
                                _displayParserErrorsIgnoredFiles.Add(currentFilePath);
                        }
                    }, noProb ? 5 : 0);
                });
            }
        }


        /// <summary>
        /// Check the parse scope has too much char to allow it to be displayed in the appbuilder
        /// </summary>
        /// <param name="pars"></param>
        private static bool CheckForTooMuchChar(ParsedScopeBlock pars) {
            // check length of block
            if (!pars.Flags.HasFlag(ParseFlag.FromInclude)) {
                pars.TooLongForAppbuilder = NbExtraCharBetweenLines(pars.Line, pars.EndBlockLine) > 0;
                if (pars.TooLongForAppbuilder)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// returns the number of chars between two lines in the current document
        /// </summary>
        private static int NbExtraCharBetweenLines(int startLine, int endLine) {
            return (Sci.StartBytePosOfLine(endLine) - Sci.StartBytePosOfLine(startLine)) - Config.Instance.GlobalMaxNbCharInBlock;
        }


    }

    /// <summary>
    /// Contains the info of a specific line number (built during the parsing)
    /// </summary>
    internal class LineInfo {

        /// <summary>
        /// Block depth for the current line (= number of indents)
        /// </summary>
        public int BlockDepth { get; set; }

        public int ExtraStatementDepth { get; set; }

        public LineInfo(int blockDepth, int extraStatementDepth) {
            BlockDepth = blockDepth;
            ExtraStatementDepth = extraStatementDepth;
        }
    }
}
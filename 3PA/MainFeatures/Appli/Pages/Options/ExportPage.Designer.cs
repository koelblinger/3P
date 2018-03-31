﻿using System.ComponentModel;
using Yamui.Framework.Controls;
using Yamui.Framework.Fonts;
using Yamui.Framework.HtmlRenderer.WinForms;

namespace _3PA.MainFeatures.Appli.Pages.Options {
    partial class ExportPage {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportPage));
            this.tooltip = new HtmlToolTip();
            this.topAuto = new HtmlLabel();
            this.btDownloadAll = new YamuiButtonImage();
            this.btRefresh = new YamuiButtonImage();
            this.topDistant = new HtmlLabel();
            this.topLocDate = new HtmlLabel();
            this.htmlLabel3 = new HtmlLabel();
            this.btHistoric = new YamuiButtonImage();
            this.btOpen = new YamuiButtonImage();
            this.fl_directory = new YamuiTextBox();
            this.btBrowse = new YamuiButtonImage();
            this.yamuiLabel2 = new YamuiLabel();
            this.lbl_about = new HtmlLabel();
            this.yamuiLabel1 = new YamuiLabel();
            this.SuspendLayout();
            // 
            // tooltip
            // 
            this.tooltip.AllowLinksHandling = true;
            this.tooltip.AutomaticDelay = 50;
            this.tooltip.AutoPopDelay = 90000;
            this.tooltip.BaseStylesheet = null;
            this.tooltip.InitialDelay = 50;
            this.tooltip.MaximumSize = new System.Drawing.Size(0, 0);
            this.tooltip.OwnerDraw = true;
            this.tooltip.ReshowDelay = 10;
            this.tooltip.UseAnimation = false;
            this.tooltip.UseFading = false;
            // 
            // scrollPanel
            // 
            // 
            // scrollPanel.ContentPanel
            // 
            this.Controls.Add(this.topAuto);
            this.Controls.Add(this.btDownloadAll);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.topDistant);
            this.Controls.Add(this.topLocDate);
            this.Controls.Add(this.htmlLabel3);
            this.Controls.Add(this.btHistoric);
            this.Controls.Add(this.btOpen);
            this.Controls.Add(this.fl_directory);
            this.Controls.Add(this.btBrowse);
            this.Controls.Add(this.yamuiLabel2);
            this.Controls.Add(this.lbl_about);
            this.Controls.Add(this.yamuiLabel1);
            // 
            // topAuto
            // 
            this.topAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.topAuto.BackColor = System.Drawing.Color.Transparent;
            this.topAuto.BaseStylesheet = null;
            this.topAuto.Location = new System.Drawing.Point(359, 191);
            this.topAuto.Name = "topAuto";
            this.topAuto.Size = new System.Drawing.Size(32, 15);
            this.topAuto.TabIndex = 118;
            this.topAuto.TabStop = false;
            this.topAuto.Text = "<b>Auto?</b>";
            // 
            // btDownloadAll
            // 
            this.btDownloadAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDownloadAll.BackGrndImage = null;
            this.btDownloadAll.Location = new System.Drawing.Point(401, 188);
            this.btDownloadAll.Margin = new System.Windows.Forms.Padding(0);
            this.btDownloadAll.Name = "btDownloadAll";
            this.btDownloadAll.SetImgSize = new System.Drawing.Size(0, 0);
            this.btDownloadAll.Size = new System.Drawing.Size(20, 20);
            this.btDownloadAll.TabIndex = 117;
            this.btDownloadAll.Text = "yamuiImageButton1";
            // 
            // btRefresh
            // 
            this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefresh.BackGrndImage = null;
            this.btRefresh.Location = new System.Drawing.Point(852, 191);
            this.btRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.SetImgSize = new System.Drawing.Size(0, 0);
            this.btRefresh.Size = new System.Drawing.Size(20, 20);
            this.btRefresh.TabIndex = 116;
            this.btRefresh.Text = "yamuiImageButton1";
            // 
            // topDistant
            // 
            this.topDistant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.topDistant.BackColor = System.Drawing.Color.Transparent;
            this.topDistant.BaseStylesheet = null;
            this.topDistant.Location = new System.Drawing.Point(671, 191);
            this.topDistant.Name = "topDistant";
            this.topDistant.Size = new System.Drawing.Size(89, 15);
            this.topDistant.TabIndex = 115;
            this.topDistant.TabStop = false;
            this.topDistant.Text = "<b>Distant file date</b>";
            // 
            // topLocDate
            // 
            this.topLocDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.topLocDate.BackColor = System.Drawing.Color.Transparent;
            this.topLocDate.BaseStylesheet = null;
            this.topLocDate.Location = new System.Drawing.Point(431, 191);
            this.topLocDate.Name = "topLocDate";
            this.topLocDate.Size = new System.Drawing.Size(77, 15);
            this.topLocDate.TabIndex = 114;
            this.topLocDate.TabStop = false;
            this.topLocDate.Text = "<b>Local file date</b>";
            // 
            // htmlLabel3
            // 
            this.htmlLabel3.AutoSize = false;
            this.htmlLabel3.AutoSizeHeightOnly = true;
            this.htmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.htmlLabel3.BaseStylesheet = null;
            this.htmlLabel3.IsSelectionEnabled = false;
            this.htmlLabel3.Location = new System.Drawing.Point(30, 155);
            this.htmlLabel3.Name = "htmlLabel3";
            this.htmlLabel3.Size = new System.Drawing.Size(186, 15);
            this.htmlLabel3.TabIndex = 113;
            this.htmlLabel3.TabStop = false;
            this.htmlLabel3.Text = "Path to the shared directory";
            // 
            // btHistoric
            // 
            this.btHistoric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btHistoric.BackGrndImage = null;
            this.btHistoric.Location = new System.Drawing.Point(852, 153);
            this.btHistoric.Margin = new System.Windows.Forms.Padding(0);
            this.btHistoric.Name = "btHistoric";
            this.btHistoric.SetImgSize = new System.Drawing.Size(0, 0);
            this.btHistoric.Size = new System.Drawing.Size(20, 20);
            this.btHistoric.TabIndex = 6;
            this.btHistoric.Text = "yamuiImageButton1";
            // 
            // btOpen
            // 
            this.btOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpen.BackGrndImage = null;
            this.btOpen.Location = new System.Drawing.Point(832, 153);
            this.btOpen.Margin = new System.Windows.Forms.Padding(0);
            this.btOpen.Name = "btOpen";
            this.btOpen.SetImgSize = new System.Drawing.Size(0, 0);
            this.btOpen.Size = new System.Drawing.Size(20, 20);
            this.btOpen.TabIndex = 5;
            this.btOpen.Text = "yamuiImageButton1";
            // 
            // fl_directory
            // 
            this.fl_directory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fl_directory.Location = new System.Drawing.Point(240, 153);
            this.fl_directory.Name = "fl_directory";
            this.fl_directory.Size = new System.Drawing.Size(566, 20);
            this.fl_directory.TabIndex = 4;
            this.fl_directory.WaterMark = "Path to the shared directory";
            // 
            // btBrowse
            // 
            this.btBrowse.BackGrndImage = null;
            this.btBrowse.Location = new System.Drawing.Point(217, 153);
            this.btBrowse.Margin = new System.Windows.Forms.Padding(0);
            this.btBrowse.Name = "btBrowse";
            this.btBrowse.SetImgSize = new System.Drawing.Size(0, 0);
            this.btBrowse.Size = new System.Drawing.Size(20, 20);
            this.btBrowse.TabIndex = 3;
            this.btBrowse.Text = "yamuiImageButton1";
            // 
            // yamuiLabel2
            // 
            this.yamuiLabel2.AutoSize = true;
            this.yamuiLabel2.Function = FontFunction.Heading;
            this.yamuiLabel2.Location = new System.Drawing.Point(0, 124);
            this.yamuiLabel2.Margin = new System.Windows.Forms.Padding(5, 18, 5, 7);
            this.yamuiLabel2.Name = "yamuiLabel2";
            this.yamuiLabel2.Size = new System.Drawing.Size(308, 19);
            this.yamuiLabel2.TabIndex = 2;
            this.yamuiLabel2.Text = "EXPORT AND SHARE YOUR CONFIGURATION";
            // 
            // lbl_about
            // 
            this.lbl_about.AutoSize = false;
            this.lbl_about.AutoSizeHeightOnly = true;
            this.lbl_about.BackColor = System.Drawing.Color.Transparent;
            this.lbl_about.BaseStylesheet = null;
            this.lbl_about.IsSelectionEnabled = false;
            this.lbl_about.Location = new System.Drawing.Point(30, 29);
            this.lbl_about.Name = "lbl_about";
            this.lbl_about.Size = new System.Drawing.Size(792, 74);
            this.lbl_about.TabIndex = 1;
            this.lbl_about.TabStop = false;
            this.lbl_about.Text = resources.GetString("lbl_about.Text");
            // 
            // yamuiLabel1
            // 
            this.yamuiLabel1.AutoSize = true;
            this.yamuiLabel1.Function = FontFunction.Heading;
            this.yamuiLabel1.Location = new System.Drawing.Point(0, 0);
            this.yamuiLabel1.Margin = new System.Windows.Forms.Padding(5, 18, 5, 7);
            this.yamuiLabel1.Name = "yamuiLabel1";
            this.yamuiLabel1.Size = new System.Drawing.Size(154, 19);
            this.yamuiLabel1.TabIndex = 0;
            this.yamuiLabel1.Text = "ABOUT THIS FEATURE";
            // 
            // ExportPage
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Name = "ExportPage";
            this.Size = new System.Drawing.Size(900, 650);
            this.ResumeLayout(false);

        }

        #endregion

        private HtmlToolTip tooltip;
        private YamuiLabel yamuiLabel1;
        private HtmlLabel lbl_about;
        private YamuiLabel yamuiLabel2;
        private YamuiButtonImage btHistoric;
        private YamuiButtonImage btOpen;
        private YamuiTextBox fl_directory;
        private YamuiButtonImage btBrowse;
        private HtmlLabel htmlLabel3;
        private HtmlLabel topDistant;
        private HtmlLabel topLocDate;
        private YamuiButtonImage btDownloadAll;
        private YamuiButtonImage btRefresh;
        private HtmlLabel topAuto;
    }
}

﻿using System.ComponentModel;
using Yamui.Framework.Controls;
using Yamui.Framework.Fonts;
using Yamui.Framework.HtmlRenderer.WinForms;

namespace _3PA.MainFeatures.Appli.Pages.Set {
    partial class SetDeploymentRules {
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
            this.linkurl = new HtmlLabel();
            this.bt_import = new YamuiButton();
            this.bt_modify = new YamuiButton();
            this.html_list = new HtmlLabel();
            this.yamuiLabel2 = new YamuiLabel();
            this.toolTip = new HtmlToolTip();
            this.SuspendLayout();
            // 
            // scrollPanel
            // 
            // 
            // scrollPanel.ContentPanel
            // 
            this.Controls.Add(this.linkurl);
            this.Controls.Add(this.bt_import);
            this.Controls.Add(this.bt_modify);
            this.Controls.Add(this.html_list);
            this.Controls.Add(this.yamuiLabel2);
            // 
            // linkurl
            // 
            this.linkurl.BackColor = System.Drawing.Color.Transparent;
            this.linkurl.BaseStylesheet = null;
            this.linkurl.Location = new System.Drawing.Point(198, 0);
            this.linkurl.Name = "linkurl";
            this.linkurl.Size = new System.Drawing.Size(161, 15);
            this.linkurl.TabIndex = 147;
            this.linkurl.TabStop = false;
            this.linkurl.Text = "Learn more about this feature?";
            // 
            // bt_import
            // 
            this.bt_import.BackGrndImage = null;
            this.bt_import.Location = new System.Drawing.Point(214, 31);
            this.bt_import.Name = "bt_import";
            this.bt_import.SetImgSize = new System.Drawing.Size(20, 20);
            this.bt_import.Size = new System.Drawing.Size(122, 24);
            this.bt_import.TabIndex = 56;
            this.bt_import.Text = "Read changes";
            // 
            // bt_modify
            // 
            this.bt_modify.BackGrndImage = null;
            this.bt_modify.Location = new System.Drawing.Point(30, 31);
            this.bt_modify.Name = "bt_modify";
            this.bt_modify.SetImgSize = new System.Drawing.Size(20, 20);
            this.bt_modify.Size = new System.Drawing.Size(178, 24);
            this.bt_modify.TabIndex = 55;
            this.bt_modify.Text = "Modify deployment rules";
            // 
            // html_list
            // 
            this.html_list.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.html_list.AutoSize = false;
            this.html_list.AutoSizeHeightOnly = true;
            this.html_list.BackColor = System.Drawing.Color.Transparent;
            this.html_list.BaseStylesheet = null;
            this.html_list.Location = new System.Drawing.Point(30, 64);
            this.html_list.Name = "html_list";
            this.html_list.Size = new System.Drawing.Size(852, 15);
            this.html_list.TabIndex = 54;
            this.html_list.TabStop = false;
            this.html_list.Text = " ?";
            // 
            // yamuiLabel2
            // 
            this.yamuiLabel2.AutoSize = true;
            this.yamuiLabel2.Function = FontFunction.Heading;
            this.yamuiLabel2.Location = new System.Drawing.Point(0, 0);
            this.yamuiLabel2.Margin = new System.Windows.Forms.Padding(5, 18, 5, 3);
            this.yamuiLabel2.Name = "yamuiLabel2";
            this.yamuiLabel2.Size = new System.Drawing.Size(146, 19);
            this.yamuiLabel2.TabIndex = 53;
            this.yamuiLabel2.Text = "DEPLOYMENT RULES";
            // 
            // toolTip
            // 
            this.toolTip.AllowLinksHandling = true;
            this.toolTip.AutoPopDelay = 90000;
            this.toolTip.BaseStylesheet = null;
            this.toolTip.InitialDelay = 300;
            this.toolTip.MaximumSize = new System.Drawing.Size(0, 0);
            this.toolTip.OwnerDraw = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // SetDeploymentRules
            // 
            this.Name = "SetDeploymentRules";
            this.Size = new System.Drawing.Size(900, 650);
            this.ResumeLayout(false);

        }

        #endregion
        
        private HtmlToolTip toolTip;
        private YamuiLabel yamuiLabel2;
        private YamuiButton bt_modify;
        private HtmlLabel html_list;
        private YamuiButton bt_import;
        private HtmlLabel linkurl;
    }
}

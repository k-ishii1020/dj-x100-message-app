﻿namespace X100_Message
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            ファイルToolStripMenuItem = new ToolStripMenuItem();
            ログクリアCToolStripMenuItem = new ToolStripMenuItem();
            終了ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            バージョン情報ToolStripMenuItem = new ToolStripMenuItem();
            djx100Ver = new ToolStripMenuItem();
            logTextBox = new TextBox();
            statusStrip1 = new StatusStrip();
            warnLabel = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            connectBtn = new Button();
            comComboBox = new ComboBox();
            comLabel = new Label();
            msgOutputBtn = new Button();
            logFileOutFlg = new CheckBox();
            ext2DisableBtn = new Button();
            ext1DisableBtn = new Button();
            ext2EnableBtn = new Button();
            ext1EnableBtn = new Button();
            label1 = new Label();
            fontSizeComboBox = new ComboBox();
            label2 = new Label();
            fontComboBox = new ComboBox();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1126, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            ファイルToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ログクリアCToolStripMenuItem, 終了ToolStripMenuItem });
            ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            ファイルToolStripMenuItem.Size = new Size(67, 20);
            ファイルToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // ログクリアCToolStripMenuItem
            // 
            ログクリアCToolStripMenuItem.Name = "ログクリアCToolStripMenuItem";
            ログクリアCToolStripMenuItem.Size = new Size(133, 22);
            ログクリアCToolStripMenuItem.Text = "ログクリア(&C)";
            ログクリアCToolStripMenuItem.Click += ログクリアCToolStripMenuItem_Click;
            // 
            // 終了ToolStripMenuItem
            // 
            終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            終了ToolStripMenuItem.Size = new Size(133, 22);
            終了ToolStripMenuItem.Text = "終了(&X)";
            終了ToolStripMenuItem.Click += 終了ToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { バージョン情報ToolStripMenuItem, djx100Ver });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(67, 20);
            toolStripMenuItem1.Text = "その他(&H)";
            // 
            // バージョン情報ToolStripMenuItem
            // 
            バージョン情報ToolStripMenuItem.Name = "バージョン情報ToolStripMenuItem";
            バージョン情報ToolStripMenuItem.Size = new Size(184, 22);
            バージョン情報ToolStripMenuItem.Text = "バージョン情報";
            バージョン情報ToolStripMenuItem.Click += バージョン情報ToolStripMenuItem_Click;
            // 
            // djx100Ver
            // 
            djx100Ver.Enabled = false;
            djx100Ver.Name = "djx100Ver";
            djx100Ver.Size = new Size(184, 22);
            djx100Ver.Text = "DJ-X100バージョン情報";
            djx100Ver.Click += djx100Ver_Click_1;
            // 
            // logTextBox
            // 
            logTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logTextBox.BackColor = SystemColors.Info;
            logTextBox.Location = new Point(12, 27);
            logTextBox.MinimumSize = new Size(400, 200);
            logTextBox.Multiline = true;
            logTextBox.Name = "logTextBox";
            logTextBox.ReadOnly = true;
            logTextBox.ScrollBars = ScrollBars.Vertical;
            logTextBox.Size = new Size(1102, 609);
            logTextBox.TabIndex = 5;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { warnLabel, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 706);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1126, 22);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // warnLabel
            // 
            warnLabel.Name = "warnLabel";
            warnLabel.Size = new Size(87, 17);
            warnLabel.Text = "接続していません";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.ImageAlign = ContentAlignment.BottomCenter;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(1024, 17);
            toolStripStatusLabel2.Spring = true;
            toolStripStatusLabel2.Text = " （秘密の保護）第59条 何人も法律に別段の定めがある場合を除くほか、特定の相手方に対して行われる無線通信を傍受してその存在若しくは内容を漏らし、又はこれを窃用してはならない。";
            toolStripStatusLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // connectBtn
            // 
            connectBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            connectBtn.Location = new Point(12, 642);
            connectBtn.Name = "connectBtn";
            connectBtn.Size = new Size(75, 23);
            connectBtn.TabIndex = 7;
            connectBtn.Text = "接続";
            connectBtn.UseVisualStyleBackColor = true;
            connectBtn.Click += ConnectBtn_Click;
            // 
            // comComboBox
            // 
            comComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comComboBox.FormattingEnabled = true;
            comComboBox.Location = new Point(159, 642);
            comComboBox.Name = "comComboBox";
            comComboBox.Size = new Size(121, 23);
            comComboBox.TabIndex = 8;
            // 
            // comLabel
            // 
            comLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comLabel.AutoSize = true;
            comLabel.Location = new Point(93, 646);
            comLabel.Name = "comLabel";
            comLabel.Size = new Size(60, 15);
            comLabel.TabIndex = 9;
            comLabel.Text = "COMポート";
            // 
            // msgOutputBtn
            // 
            msgOutputBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            msgOutputBtn.Enabled = false;
            msgOutputBtn.Location = new Point(12, 671);
            msgOutputBtn.Name = "msgOutputBtn";
            msgOutputBtn.Size = new Size(117, 23);
            msgOutputBtn.TabIndex = 10;
            msgOutputBtn.Text = "メッセージ出力開始";
            msgOutputBtn.UseVisualStyleBackColor = true;
            msgOutputBtn.Click += MsgOutputBtn_Click;
            // 
            // logFileOutFlg
            // 
            logFileOutFlg.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            logFileOutFlg.AutoSize = true;
            logFileOutFlg.Location = new Point(159, 675);
            logFileOutFlg.Name = "logFileOutFlg";
            logFileOutFlg.Size = new Size(68, 19);
            logFileOutFlg.TabIndex = 11;
            logFileOutFlg.Text = "ログ出力";
            logFileOutFlg.UseVisualStyleBackColor = true;
            // 
            // ext2DisableBtn
            // 
            ext2DisableBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ext2DisableBtn.Enabled = false;
            ext2DisableBtn.Location = new Point(1001, 671);
            ext2DisableBtn.Name = "ext2DisableBtn";
            ext2DisableBtn.Size = new Size(113, 23);
            ext2DisableBtn.TabIndex = 13;
            ext2DisableBtn.Text = "拡張機能2無効化";
            ext2DisableBtn.UseVisualStyleBackColor = true;
            ext2DisableBtn.Click += ext2DisableBtn_Click;
            // 
            // ext1DisableBtn
            // 
            ext1DisableBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ext1DisableBtn.Enabled = false;
            ext1DisableBtn.Location = new Point(880, 671);
            ext1DisableBtn.Name = "ext1DisableBtn";
            ext1DisableBtn.Size = new Size(115, 23);
            ext1DisableBtn.TabIndex = 14;
            ext1DisableBtn.Text = "拡張機能1無効化";
            ext1DisableBtn.UseVisualStyleBackColor = true;
            ext1DisableBtn.Click += ext1DisableBtn_Click;
            // 
            // ext2EnableBtn
            // 
            ext2EnableBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ext2EnableBtn.Enabled = false;
            ext2EnableBtn.Location = new Point(1001, 642);
            ext2EnableBtn.Name = "ext2EnableBtn";
            ext2EnableBtn.Size = new Size(113, 23);
            ext2EnableBtn.TabIndex = 15;
            ext2EnableBtn.Text = "拡張機能2有効化";
            ext2EnableBtn.UseVisualStyleBackColor = true;
            ext2EnableBtn.Click += ext2EnableBtn_Click;
            // 
            // ext1EnableBtn
            // 
            ext1EnableBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ext1EnableBtn.Enabled = false;
            ext1EnableBtn.Location = new Point(880, 642);
            ext1EnableBtn.Name = "ext1EnableBtn";
            ext1EnableBtn.Size = new Size(115, 23);
            ext1EnableBtn.TabIndex = 16;
            ext1EnableBtn.Text = "拡張機能1有効化";
            ext1EnableBtn.UseVisualStyleBackColor = true;
            ext1EnableBtn.Click += ext1EnableBtn_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(233, 676);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 17;
            label1.Text = "フォント";
            // 
            // fontSizeComboBox
            // 
            fontSizeComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            fontSizeComboBox.FormattingEnabled = true;
            fontSizeComboBox.Location = new Point(279, 671);
            fontSizeComboBox.Name = "fontSizeComboBox";
            fontSizeComboBox.Size = new Size(43, 23);
            fontSizeComboBox.TabIndex = 18;
            fontSizeComboBox.SelectedIndexChanged += FontSizeComboBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(324, 676);
            label2.Name = "label2";
            label2.Size = new Size(18, 15);
            label2.TabIndex = 19;
            label2.Text = "pt";
            // 
            // fontComboBox
            // 
            fontComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            fontComboBox.FormattingEnabled = true;
            fontComboBox.Location = new Point(348, 671);
            fontComboBox.Name = "fontComboBox";
            fontComboBox.Size = new Size(121, 23);
            fontComboBox.TabIndex = 20;
            fontComboBox.SelectedIndexChanged += FontComboBox_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1126, 728);
            Controls.Add(fontComboBox);
            Controls.Add(label2);
            Controls.Add(fontSizeComboBox);
            Controls.Add(label1);
            Controls.Add(ext1EnableBtn);
            Controls.Add(ext2EnableBtn);
            Controls.Add(ext1DisableBtn);
            Controls.Add(ext2DisableBtn);
            Controls.Add(logFileOutFlg);
            Controls.Add(msgOutputBtn);
            Controls.Add(comLabel);
            Controls.Add(comComboBox);
            Controls.Add(connectBtn);
            Controls.Add(statusStrip1);
            Controls.Add(logTextBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(750, 400);
            Name = "Form1";
            Text = "DJ-X100 メッセージロガー";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ファイルToolStripMenuItem;
        private ToolStripMenuItem 終了ToolStripMenuItem;
        private TextBox logTextBox;
        private StatusStrip statusStrip1;
        private Button connectBtn;
        private ComboBox comComboBox;
        private Label comLabel;
        private Button msgOutputBtn;
        private CheckBox logFileOutFlg;
        private ToolStripStatusLabel warnLabel;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripMenuItem ログクリアCToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem バージョン情報ToolStripMenuItem;
        private Button ext2DisableBtn;
        private Button ext1DisableBtn;
        private Button ext2EnableBtn;
        private Button ext1EnableBtn;
        private ToolStripMenuItem djx100Ver;
        private Label label1;
        private ComboBox fontSizeComboBox;
        private Label label2;
        private ComboBox fontComboBox;
    }
}
namespace X100_Message
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
            終了ToolStripMenuItem = new ToolStripMenuItem();
            logTextBox = new TextBox();
            statusStrip1 = new StatusStrip();
            warnLabel = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            connectBtn = new Button();
            comComboBox = new ComboBox();
            comLabel = new Label();
            msgOutputBtn = new Button();
            logFileOutFlg = new CheckBox();
            ログクリアCToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルToolStripMenuItem });
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
            // 終了ToolStripMenuItem
            // 
            終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            終了ToolStripMenuItem.Size = new Size(180, 22);
            終了ToolStripMenuItem.Text = "終了(&X)";
            終了ToolStripMenuItem.Click += 終了ToolStripMenuItem_Click;
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
            logTextBox.Size = new Size(1102, 631);
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
            connectBtn.Location = new Point(12, 664);
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
            comComboBox.Location = new Point(291, 664);
            comComboBox.Name = "comComboBox";
            comComboBox.Size = new Size(121, 23);
            comComboBox.TabIndex = 8;
            // 
            // comLabel
            // 
            comLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comLabel.AutoSize = true;
            comLabel.Location = new Point(225, 668);
            comLabel.Name = "comLabel";
            comLabel.Size = new Size(60, 15);
            comLabel.TabIndex = 9;
            comLabel.Text = "COMポート";
            // 
            // msgOutputBtn
            // 
            msgOutputBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            msgOutputBtn.Enabled = false;
            msgOutputBtn.Location = new Point(102, 664);
            msgOutputBtn.Name = "msgOutputBtn";
            msgOutputBtn.Size = new Size(117, 23);
            msgOutputBtn.TabIndex = 10;
            msgOutputBtn.Text = "メッセージ出力開始";
            msgOutputBtn.UseVisualStyleBackColor = true;
            msgOutputBtn.Click += MsgOutputBtn_Click;
            // 
            // logFileOutFlg
            // 
            logFileOutFlg.AutoSize = true;
            logFileOutFlg.Location = new Point(418, 666);
            logFileOutFlg.Name = "logFileOutFlg";
            logFileOutFlg.Size = new Size(68, 19);
            logFileOutFlg.TabIndex = 11;
            logFileOutFlg.Text = "ログ出力";
            logFileOutFlg.UseVisualStyleBackColor = true;
            // 
            // ログクリアCToolStripMenuItem
            // 
            ログクリアCToolStripMenuItem.Name = "ログクリアCToolStripMenuItem";
            ログクリアCToolStripMenuItem.Size = new Size(180, 22);
            ログクリアCToolStripMenuItem.Text = "ログクリア(&C)";
            ログクリアCToolStripMenuItem.Click += ログクリアCToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1126, 728);
            Controls.Add(logFileOutFlg);
            Controls.Add(msgOutputBtn);
            Controls.Add(comLabel);
            Controls.Add(comComboBox);
            Controls.Add(connectBtn);
            Controls.Add(statusStrip1);
            Controls.Add(logTextBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(600, 400);
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
    }
}
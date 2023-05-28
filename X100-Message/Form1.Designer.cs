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
            ログクリアCToolStripMenuItem = new ToolStripMenuItem();
            終了ToolStripMenuItem = new ToolStripMenuItem();
            extMenuItem = new ToolStripMenuItem();
            ext1MenuItem = new ToolStripMenuItem();
            ext1EnableBtn = new ToolStripMenuItem();
            ext1DisableBtn = new ToolStripMenuItem();
            ext2MenuItem = new ToolStripMenuItem();
            ext2EnableBtn = new ToolStripMenuItem();
            ext2DisableBtn = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            バージョン情報ToolStripMenuItem = new ToolStripMenuItem();
            logTextBox = new TextBox();
            statusStrip1 = new StatusStrip();
            warnLabel = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            connectBtn = new Button();
            comComboBox = new ComboBox();
            comLabel = new Label();
            msgOutputBtn = new Button();
            isLogFileOutput = new CheckBox();
            label1 = new Label();
            fontSizeComboBox = new ComboBox();
            label2 = new Label();
            fontComboBox = new ComboBox();
            mcuLabel = new Label();
            groupBox1 = new GroupBox();
            ext2Label = new Label();
            ext1Label = new Label();
            restartBtn = new Button();
            searchBtn = new Button();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ファイルToolStripMenuItem, extMenuItem, toolStripMenuItem1 });
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
            // extMenuItem
            // 
            extMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ext1MenuItem, ext2MenuItem });
            extMenuItem.Enabled = false;
            extMenuItem.Name = "extMenuItem";
            extMenuItem.Size = new Size(81, 20);
            extMenuItem.Text = "拡張機能(&E)";
            // 
            // ext1MenuItem
            // 
            ext1MenuItem.DropDownItems.AddRange(new ToolStripItem[] { ext1EnableBtn, ext1DisableBtn });
            ext1MenuItem.Name = "ext1MenuItem";
            ext1MenuItem.Size = new Size(128, 22);
            ext1MenuItem.Text = "拡張機能1";
            // 
            // ext1EnableBtn
            // 
            ext1EnableBtn.Name = "ext1EnableBtn";
            ext1EnableBtn.Size = new Size(110, 22);
            ext1EnableBtn.Text = "有効化";
            ext1EnableBtn.Click += ext1EnableBtn_Click;
            // 
            // ext1DisableBtn
            // 
            ext1DisableBtn.Name = "ext1DisableBtn";
            ext1DisableBtn.Size = new Size(110, 22);
            ext1DisableBtn.Text = "無効化";
            ext1DisableBtn.Click += ext1DisableBtn_Click;
            // 
            // ext2MenuItem
            // 
            ext2MenuItem.DropDownItems.AddRange(new ToolStripItem[] { ext2EnableBtn, ext2DisableBtn });
            ext2MenuItem.Name = "ext2MenuItem";
            ext2MenuItem.Size = new Size(128, 22);
            ext2MenuItem.Text = "拡張機能2";
            // 
            // ext2EnableBtn
            // 
            ext2EnableBtn.Name = "ext2EnableBtn";
            ext2EnableBtn.Size = new Size(110, 22);
            ext2EnableBtn.Text = "有効化";
            ext2EnableBtn.Click += ext2EnableBtn_Click;
            // 
            // ext2DisableBtn
            // 
            ext2DisableBtn.Name = "ext2DisableBtn";
            ext2DisableBtn.Size = new Size(110, 22);
            ext2DisableBtn.Text = "無効化";
            ext2DisableBtn.Click += ext2DisableBtn_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { バージョン情報ToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(67, 20);
            toolStripMenuItem1.Text = "その他(&H)";
            // 
            // バージョン情報ToolStripMenuItem
            // 
            バージョン情報ToolStripMenuItem.Name = "バージョン情報ToolStripMenuItem";
            バージョン情報ToolStripMenuItem.Size = new Size(142, 22);
            バージョン情報ToolStripMenuItem.Text = "バージョン情報";
            バージョン情報ToolStripMenuItem.Click += バージョン情報ToolStripMenuItem_Click;
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
            logTextBox.Size = new Size(1102, 564);
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
            // isLogFileOutput
            // 
            isLogFileOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            isLogFileOutput.AutoSize = true;
            isLogFileOutput.Location = new Point(159, 675);
            isLogFileOutput.Name = "isLogFileOutput";
            isLogFileOutput.Size = new Size(68, 19);
            isLogFileOutput.TabIndex = 11;
            isLogFileOutput.Text = "ログ出力";
            isLogFileOutput.UseVisualStyleBackColor = true;
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
            // mcuLabel
            // 
            mcuLabel.AutoSize = true;
            mcuLabel.Location = new Point(6, 19);
            mcuLabel.Name = "mcuLabel";
            mcuLabel.Size = new Size(23, 15);
            mcuLabel.TabIndex = 21;
            mcuLabel.Text = "ver";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox1.Controls.Add(ext2Label);
            groupBox1.Controls.Add(ext1Label);
            groupBox1.Controls.Add(mcuLabel);
            groupBox1.Location = new Point(937, 620);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(177, 83);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "DJ-X100情報";
            // 
            // ext2Label
            // 
            ext2Label.AutoSize = true;
            ext2Label.Location = new Point(6, 59);
            ext2Label.Name = "ext2Label";
            ext2Label.Size = new Size(64, 15);
            ext2Label.TabIndex = 23;
            ext2Label.Text = "拡張機能2:";
            // 
            // ext1Label
            // 
            ext1Label.AutoSize = true;
            ext1Label.Location = new Point(6, 39);
            ext1Label.Name = "ext1Label";
            ext1Label.Size = new Size(64, 15);
            ext1Label.TabIndex = 22;
            ext1Label.Text = "拡張機能1:";
            // 
            // restartBtn
            // 
            restartBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            restartBtn.Enabled = false;
            restartBtn.Location = new Point(833, 676);
            restartBtn.Name = "restartBtn";
            restartBtn.Size = new Size(98, 23);
            restartBtn.TabIndex = 23;
            restartBtn.Text = "DJ-X100再起動";
            restartBtn.UseVisualStyleBackColor = true;
            restartBtn.Click += restartBtn_Click;
            // 
            // searchBtn
            // 
            searchBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            searchBtn.Enabled = false;
            searchBtn.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            searchBtn.Location = new Point(897, 646);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(34, 28);
            searchBtn.TabIndex = 24;
            searchBtn.Text = "🔎";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += search_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1126, 728);
            Controls.Add(searchBtn);
            Controls.Add(restartBtn);
            Controls.Add(groupBox1);
            Controls.Add(fontComboBox);
            Controls.Add(label2);
            Controls.Add(fontSizeComboBox);
            Controls.Add(label1);
            Controls.Add(isLogFileOutput);
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
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private CheckBox isLogFileOutput;
        private ToolStripStatusLabel warnLabel;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripMenuItem ログクリアCToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem バージョン情報ToolStripMenuItem;
        private Label label1;
        private ComboBox fontSizeComboBox;
        private Label label2;
        private ComboBox fontComboBox;
        private ToolStripMenuItem extMenuItem;
        private ToolStripMenuItem ext1MenuItem;
        private ToolStripMenuItem ext1EnableBtn;
        private ToolStripMenuItem ext1DisableBtn;
        private ToolStripMenuItem ext2MenuItem;
        private ToolStripMenuItem ext2EnableBtn;
        private ToolStripMenuItem ext2DisableBtn;
        private Label mcuLabel;
        private GroupBox groupBox1;
        private Label ext1Label;
        private Label ext2Label;
        private Button restartBtn;
        private Button searchBtn;
    }
}
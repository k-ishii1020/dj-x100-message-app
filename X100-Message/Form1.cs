namespace X100_Message
{
    public partial class Form1 : Form
    {
        private string version = "2.0.0";
        Uart uart = new();
        Extend extend = new();

        private bool isWaitMessage = false;
        private bool isRestart = false;

        public Form1()
        {
            InitializeComponent();
            uart.DataReceived += DataReceived;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitComPort();
            InitFont();
            this.Text = "DJ-X100 メッセージロガー Ver" + version;


        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            uart.Close();
            Application.Exit();
        }

        private String SendCmd(string cmd)
        {
            String response = uart.SendCmd(cmd).Replace("\r\n", "");

            if (response.Equals(Command.NG))
            {
                MessageBox.Show("応答異常", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "レスポンス異常";
            }

            return response;
        }

        private bool SendCmd(string cmd, string expectResponse)
        {
            String response = uart.SendCmd(cmd).Replace("\r\n", "");

            if (response.Equals(Command.NG))
            {
                MessageBox.Show("応答異常", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (response.Equals(expectResponse)) return true;
            return false;
        }

        private String SendRawdCmd(String cmd)
        {
            String response = uart.SendRawCmd(cmd).Replace("\r\n", "");

            if (response.Equals(Command.NG))
            {
                MessageBox.Show("応答異常", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "レスポンス異常";
            }

            return response;
        }

        private void ConnectX100()
        {
            if (uart.InitSerialPort(comComboBox.Text))
            {
                if (SendCmd(Command.WHO, "DJ-X100"))
                {

                    //if (!isRestart && SendCmd(Command.DSPTHRU, "  SLEEP"))
                    //{
                    //    MessageBox.Show("電源が入っていません", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //     CloseConnection();
                    //     return;
                    // }

                    connectBtn.Text = "切断";
                    msgOutputBtn.Enabled = true;
                    extMenuItem.Enabled = true;
                    restartBtn.Enabled = true;

                    warnLabel.Text = "DJ-X100接続済み";

                    GetX100Info();
                }
                else
                {
                    warnLabel.Text = "接続失敗";
                    MessageBox.Show("接続エラーが発生しました: ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseConnection();
                }

            }
        }

        // DJ-X100に接続
        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (connectBtn.Text.Equals("切断"))
            {
                CloseConnection();
                return;
            }

            ConnectX100();

        }

        private void GetX100Info()
        {
            mcuLabel.Text = SendCmd(Command.VER);
            ext1Label.Text = SendCmd(Command.EXT1_IS_VAILD, Command.ENABLE) ? "拡張機能1:有効" : "拡張機能1:無効";
            ext2Label.Text = SendCmd(Command.EXT2_IS_VAILD, Command.ENABLE) ? "拡張機能2:有効" : "拡張機能2:無効";
        }




        //非同期でコマンド受信待機している（イベントハンドラ）
        private void DataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!isWaitMessage) return;

            String response = e.Data;
            if (response.Equals("\r\nOK\r\n")) return;

            // 受信データをテキストボックスに表示（UIスレッドで実行）
            this.Invoke(new Action(() =>
            {
                DateTime now = DateTime.Now;
                logTextBox.AppendText($"{now} >> {response}\r\n");

                if (logFileOutFlg.Checked)
                {
                    try
                    {
                        File.AppendAllText($"received_message_{now.ToString("yyyyMMdd")}.txt", $"{now} >> {response}" + Environment.NewLine);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("メッセージログ出力エラー " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }));
        }

        private void CloseConnection()
        {
            uart.Close();
            warnLabel.Text = "接続していません";
            connectBtn.Text = "接続";

            msgOutputBtn.Enabled = false;
            extMenuItem.Enabled = false;
            restartBtn.Enabled = false;

            mcuLabel.Text = "ver";
            ext1Label.Text = "拡張機能1:";
            ext2Label.Text = "拡張機能2:";
        }


        private void MsgOutputBtn_Click(object sender, EventArgs e)
        {
            if (isWaitMessage)
            {
                if (SendRawdCmd("QUIT\r\n").Equals(Command.OK))
                {
                    msgOutputBtn.Text = "メッセージ出力開始";
                    warnLabel.Text = "DJ-X100接続済み";
                    extMenuItem.Enabled = true;
                    restartBtn.Enabled = true;
                    isWaitMessage = false;
                }
                return;
            }

            if (SendCmd(Command.OUTLINE, Command.OK))
            {
                msgOutputBtn.Text = "メッセージ出力終了";
                warnLabel.Text = "メッセージ待機中…(周波数等の変更無効)";
                extMenuItem.Enabled = false;
                restartBtn.Enabled= false;
                isWaitMessage = true;
            }
        }

        // COMポート一覧の初期化処理
        private void InitComPort()
        {
            foreach (String portName in Uart.GetPortLists())
            {
                comComboBox.Items.Add(portName);
            }
            if (comComboBox.Items.Count > 0)
            {
                comComboBox.SelectedIndex = 0;
            }
        }

        private void InitFont()
        {
            fontSizeComboBox.Items.Add("7");
            fontSizeComboBox.Items.Add("8");
            fontSizeComboBox.Items.Add("10");
            fontSizeComboBox.Items.Add("12");
            fontSizeComboBox.Items.Add("14");
            fontSizeComboBox.Items.Add("16");
            fontSizeComboBox.Items.Add("18");
            fontSizeComboBox.Items.Add("20");
            fontSizeComboBox.Items.Add("24");
            // デフォルトのフォントサイズを設定
            float defaultFontSize = 8.0f;
            logTextBox.Font = new Font(logTextBox.Font.FontFamily, defaultFontSize);
            fontSizeComboBox.SelectedItem = defaultFontSize.ToString();
            foreach (FontFamily font in FontFamily.Families)
            {
                fontComboBox.Items.Add(font.Name);
            }
            // デフォルトのフォントを設定
            fontComboBox.SelectedItem = logTextBox.Font.FontFamily.Name;

        }

        private void FontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFontSize = (string)fontSizeComboBox.SelectedItem;
            float fontSize = 8.0f;
            if (float.TryParse(selectedFontSize, out fontSize))
            {
                float.Parse(selectedFontSize);
            }
            logTextBox.Font = new Font(logTextBox.Font.FontFamily, fontSize);
        }

        private void FontComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFont = (string)fontComboBox.SelectedItem;
            logTextBox.Font = new Font(selectedFont, logTextBox.Font.Size);
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uart.Close();
            Application.Exit();
        }

        private void ログクリアCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logTextBox.ResetText();
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DJ-X100メッセージロガー\nVer" + version + "\nCopyright(C) 2023 by kaz", "バージョン情報", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void ext1EnableBtn_Click(object sender, EventArgs e)
        {
            extend.IsExtendAccept(sender);
        }

        private void ext1DisableBtn_Click(object sender, EventArgs e)
        {
            if (extend.IsExtendAccept(sender))
            {

                if (SendCmd(Command.EXT1_DISABLE, Command.OK))
                {
                    MessageBox.Show("拡張機能1を無効化しました", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                ext1Label.Text = SendCmd(Command.EXT1_IS_VAILD, Command.ENABLE) ? "拡張機能1:有効" : "拡張機能1:無効";
            }
        }

        private void ext2EnableBtn_Click(object sender, EventArgs e)
        {
            if (extend.IsExtendAccept(sender))
            {
                if (SendCmd(Command.EXT2_ENABLE, Command.OK))
                {
                    MessageBox.Show("拡張機能2を有効化しました", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                ext2Label.Text = SendCmd(Command.EXT2_IS_VAILD, Command.ENABLE) ? "拡張機能2:有効" : "拡張機能2:無効";
            }
        }
        private void ext2DisableBtn_Click(object sender, EventArgs e)
        {
            if (extend.IsExtendAccept(sender))
            {
                if (SendCmd(Command.EXT2_DISABLE, Command.OK))
                {
                    MessageBox.Show("拡張機能2を無効化しました", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                ext2Label.Text = SendCmd(Command.EXT2_IS_VAILD, Command.ENABLE) ? "拡張機能2:有効" : "拡張機能2:無効";
            }
        }

        private async void restartBtn_Click(object sender, EventArgs e)
        {
            if (SendCmd(Command.RESTART, Command.OK))
            {
                isRestart = true;
                CloseConnection();
                await Task.Delay(5000);

                ConnectX100();
            }
        }
    }


}
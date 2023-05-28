namespace X100_Message
{
    public partial class Form1 : Form
    {
        private string version = "2.0.0";
        Uart uart = new();
        Extend extend = new();

        private bool isWaitMessage = false;
        private bool isRestart = false;
        List<string> controlNamesToSave = new List<string>() { "isLogFileOutput", "comComboBox", "fontSizeComboBox", "fontComboBox" };

        /**
         * Form系
         */
        public Form1()
        {
            InitializeComponent();
            uart.DataReceived += DataReceived;
            this.FormClosing += Form1_FormClosing;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitComPort();
            InitFont();
            InitLogOutput();
            this.Text = "DJ-X100 メッセージロガー Ver" + version;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
            SaveFormContentToIniFile();
            Application.Exit();
        }
        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseConnection();
            SaveFormContentToIniFile();
            Application.Exit();
        }

        // COMポート一覧の初期化処理
        private void InitComPort()
        {
            // 設定ファイルから選択されたCOMポートを取得します。
            string selectedComPort = IniFileHandler.ReadValue("Settings", "comComboBox", ".\\settings.ini");

            foreach (String portName in Uart.GetPortLists())
            {
                comComboBox.Items.Add(portName);

                // 読み取ったCOMポートと一致するものがあれば、それを選択します。
                if (portName == selectedComPort)
                {
                    comComboBox.SelectedItem = portName;
                }
            }

            // 設定ファイルに一致するCOMポートが見つからなかった場合、最初のポートを選択します。
            if (comComboBox.SelectedItem == null && comComboBox.Items.Count > 0)
            {
                comComboBox.SelectedIndex = 0;
            }
        }

        private void InitFont()
        {
            // iniファイルから設定を読み込む
            string selectedFont = IniFileHandler.ReadValue("Settings", "fontComboBox", ".\\settings.ini");
            string selectedFontSize = IniFileHandler.ReadValue("Settings", "fontSizeComboBox", ".\\settings.ini");
            float fontSize = 8.0f;

            // フォントサイズのコンボボックスを初期化
            fontSizeComboBox.Items.AddRange(new string[] { "7", "8", "10", "12", "14", "16", "18", "20", "24" });
            if (!string.IsNullOrEmpty(selectedFontSize) && float.TryParse(selectedFontSize, out fontSize))
            {
                fontSizeComboBox.SelectedItem = selectedFontSize;
            }
            else
            {
                fontSizeComboBox.SelectedItem = "8";
            }

            foreach (FontFamily font in FontFamily.Families)
            {
                fontComboBox.Items.Add(font.Name);

                if (font.Name == selectedFont)
                {
                    fontComboBox.SelectedItem = font.Name;
                }
            }

            if (fontComboBox.SelectedItem == null || fontSize <= 0)
            {
                logTextBox.Font = new Font("BIZ UDPゴシック", 8.0f);
            }
            else
            {
                logTextBox.Font = new Font(selectedFont, fontSize);
            }
        }

        private void InitLogOutput()
        {
            string checkBoxValueString = IniFileHandler.ReadValue("Settings", "isLogFileOutput", ".\\settings.ini");
            bool checkBoxValue = false;
            bool.TryParse(checkBoxValueString, out checkBoxValue);
            isLogFileOutput.Checked = checkBoxValue;
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

        private void SaveFormContentToIniFile()
        {
            string filePath = ".\\settings.ini";
            IniFileHandler.WriteValue("Settings", "isLogFileOutput", isLogFileOutput.Checked.ToString(), ".\\settings.ini");


            foreach (string controlName in controlNamesToSave)
            {
                Control control = this.Controls.Find(controlName, true).FirstOrDefault();
                IniFileHandler.WriteValue("Version", "Ver", version, filePath);

                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    IniFileHandler.WriteValue("Settings", textBox.Name, textBox.Text, filePath);
                }
                else if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    IniFileHandler.WriteValue("Settings", comboBox.Name, comboBox.Text, filePath);
                }
            }
        }


        /**
         * コマンド系
         */
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
                    String isPower = SendCmd(Command.DSPTHRU);

                    if (!isRestart && isPower.Equals("  SLEEP"))
                    {
                        MessageBox.Show("電源が入っていません", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseConnection();
                        return;
                    }
                    if (isPower.Equals("誓約していない"))
                    {
                        CloseConnection();
                        return;
                    }

                    connectBtn.Text = "切断";
                    msgOutputBtn.Enabled = true;
                    extMenuItem.Enabled = true;
                    restartBtn.Enabled = true;
                    searchBtn.Enabled = true;

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

                if (isLogFileOutput.Checked)
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
            if (isWaitMessage)
            {
                SendRawdCmd("QUIT\r\n");
                isWaitMessage = false;
            }
            uart.Close();
            warnLabel.Text = "接続していません";
            connectBtn.Text = "接続";

            msgOutputBtn.Enabled = false;
            msgOutputBtn.Text = "メッセージ出力開始";
            extMenuItem.Enabled = false;
            restartBtn.Enabled = false;
            searchBtn.Enabled = false;

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
                    searchBtn.Enabled = true;
                    isWaitMessage = false;
                }
                return;
            }

            if (SendCmd(Command.OUTLINE, Command.OK))
            {
                msgOutputBtn.Text = "メッセージ出力終了";
                warnLabel.Text = "メッセージ待機中…(周波数等の変更無効)";
                extMenuItem.Enabled = false;
                restartBtn.Enabled = false;
                searchBtn.Enabled = false;
                isWaitMessage = true;
            }
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

                if ((SendCmd(Command.EXT2_DISABLE, Command.OK) && SendCmd(Command.EXT1_DISABLE, Command.OK)))
                {
                    MessageBox.Show("拡張機能1,2を無効化しました", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                ext1Label.Text = SendCmd(Command.EXT1_IS_VAILD, Command.ENABLE) ? "拡張機能1:有効" : "拡張機能1:無効";
                ext2Label.Text = SendCmd(Command.EXT2_IS_VAILD, Command.ENABLE) ? "拡張機能2:有効" : "拡張機能2:無効";

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
                restartBtn.Text = "再起動中…";
                warnLabel.Text = "再起動中…";
                await Task.Delay(5000);

                ConnectX100();
                restartBtn.Text = "DJ-X100再起動";
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            SendCmd(Command.FUNC);
            SendCmd(Command.KEY_0);
        }
    }


}
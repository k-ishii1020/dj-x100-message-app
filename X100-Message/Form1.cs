namespace X100_Message
{
    public partial class Form1 : Form
    {
        Uart uart = new Uart();

        // 
        private bool firstConnectFlg = true;
        private bool djx100ConnectFlg = false;
        private string lastSendCmd = "";

        public Form1()
        {
            InitializeComponent();
            uart.DataReceived += DataReceived;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitComPort();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            uart.Close();
            Application.Exit();
        }

        private void SendCmd(string cmd)
        {
            lastSendCmd = cmd;
            uart.SendCmd(cmd);
        }

        // DJ-X100に接続
        private async void ConnectBtn_Click(object sender, EventArgs e)
        {

            if (connectBtn.Text.Equals("切断"))
            {
                CloseConnection();
                return;
            }


            if (uart.InitSerialPort(comComboBox.Text))
            {
                await Task.Delay(500); // 非同期で受信しているため待機

                if (djx100ConnectFlg)
                {
                    connectBtn.Text = "切断";
                    msgOutputBtn.Enabled = true;
                    djx100Ver.Enabled = true;
                    ext1EnableBtn.Enabled = true;
                    ext1DisableBtn.Enabled = true;
                    ext2EnableBtn.Enabled = true;
                    ext2DisableBtn.Enabled = true;
                }
                else
                {
                    MessageBox.Show("接続エラーが発生しました: ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseConnection();
                }

            }
        }



        //非同期でコマンド受信待機している（イベントハンドラ）
        private void DataReceived(object sender, DataReceivedEventArgs e)
        {
            var response = e.Data;

            // 初回受信時
            if (firstConnectFlg)
            {
                if (response.Equals("\r\nDJ-X100\r\n"))
                {
                    djx100ConnectFlg = true;
                    firstConnectFlg = false;
                    warnLabel.Text = "DJ-X100接続済み";

                }
                else
                {
                    warnLabel.Text = "接続失敗";
                }
                return;
            }

            switch (lastSendCmd)
            {
                case Command.VER:
                    MessageBox.Show(response, "DJ-X100バージョン情報", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                case Command.EXT1_DISABLE:
                    MessageBox.Show("拡張機能1を無効化しました", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                case Command.EXT2_ENABLE:
                    MessageBox.Show("拡張機能2を有効化しました", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                case Command.EXT2_DISABLE:
                    MessageBox.Show("拡張機能2を無効化しました", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;


                default:
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
                    break;

            }
        }

        private void CloseConnection()
        {
            uart.Close();
            MessageBox.Show("再接続する場合はDJ-X100を再起動してください", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            warnLabel.Text = "接続していません";
            connectBtn.Text = "接続";
            msgOutputBtn.Text = "メッセージ出力開始";
            msgOutputBtn.Enabled = false;
            firstConnectFlg = true;
        }


        private void MsgOutputBtn_Click(object sender, EventArgs e)
        {
            if (msgOutputBtn.Text.Equals("メッセージ出力終了") && uart.IsOpen())
            {
                CloseConnection();
                return;
            }

            msgOutputBtn.Text = "メッセージ出力終了";
            djx100Ver.Enabled = false;
            ext1EnableBtn.Enabled = false;
            ext1DisableBtn.Enabled = false;
            ext2EnableBtn.Enabled = false;
            ext2DisableBtn.Enabled = false;
            SendCmd(Command.OUTLINE);
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

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uart.Close();
            Application.Exit();
        }

        private void ログクリアCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logTextBox.ResetText();
        }

        private void djx100Ver_Click(object sender, EventArgs e)
        {
            SendCmd(Command.VER);
        }

        private void バージョン情報ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DJ-X100メッセージロガー\nVer1.2.0\nCopyright(C) 2023 by kaz", "バージョン情報", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }


        private void ext1DisableBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("拡張機能関連の操作は自己責任です。\nよろしいですか？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SendCmd(Command.EXT1_DISABLE);
            }
        }

        private void ext2EnableBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("拡張機能関連の操作は自己責任です。\nよろしいですか？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SendCmd(Command.EXT2_ENABLE);
            }
        }
        private void ext2DisableBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("拡張機能関連の操作は自己責任です。\nよろしいですか？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SendCmd(Command.EXT2_DISABLE);
            }

        }

        private void ext1EnableBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("工事中", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }
    }


}
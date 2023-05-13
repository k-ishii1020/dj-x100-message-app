namespace X100_Message
{
    public partial class Form1 : Form
    {
        Uart uart = new Uart();


        // 
        private bool firstConnectFlg = true;
        private bool djx100ConnectFlg = false;
        private string lastCommandSent = "";

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

        // 無線機に接続
        private async void ConnectBtn_Click(object sender, EventArgs e)
        {

            if (connectBtn.Text.Equals("切断"))
            {
                CloseConnection();
                return;
            }


            if (uart.InitSerialPort(comComboBox.Text))
            {
                await Task.Delay(500);

                if (djx100ConnectFlg)
                {
                    connectBtn.Text = "切断";
                    msgOutputBtn.Enabled = true;
                }
                else
                {
                    MessageBox.Show("接続エラーが発生しました: ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CloseConnection();
                }

            }
        }




        private void DataReceived(object sender, DataReceivedEventArgs e)
        {
            var response = e.Data;


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

            switch (lastCommandSent)
            {
                case "VER":
                    MessageBox.Show(response, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

            //await Task.Delay(100);
            uart.SendCmd(Command.OUTLINE);
        }



        // COMポート一覧の初期化処理
        private void InitComPort()
        {
            foreach (String portName in uart.GetPortLists())
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

    }


}
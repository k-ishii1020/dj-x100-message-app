using System.IO.Ports;
using System.Text;



namespace X100_Message
{
    public partial class Form1 : Form
    {

        private static string DJ_X100_OPEN = "AL~DJ-X100\r";
        private SerialPort serialPort;

        private bool firstConnectFlg = true;
        private bool djx100ConnextFlg = false;

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitComPort();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
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
            if (InitSerialPort())
            {
                await Task.Delay(500);

                if (djx100ConnextFlg)
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

        private bool InitSerialPort()
        {
            // COMポートの設定
            var portName = comComboBox.Text;
            var baudRate = 9600;
            var dataBits = 8;
            var parity = Parity.None;
            var stopBits = StopBits.One;

            serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            serialPort.DtrEnable = true;
            serialPort.RtsEnable = true;

            serialPort.DataReceived += SerialPort_DataReceived;

            try
            {
                serialPort.Open();
                var open = Encoding.ASCII.GetBytes(DJ_X100_OPEN);
                serialPort.BaseStream.WriteAsync(open, 0, open.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("接続エラーが発生しました: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serialPort.Close();
                return false;
            }
            return true;
        }


        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = (SerialPort)sender;
            var buffer = new byte[serialPort.BytesToRead];
            var bytesRead = serialPort.Read(buffer, 0, buffer.Length);
            var response = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            if (firstConnectFlg)
            {
                if (response.Equals("\r\nOK\r\n"))
                {
                    djx100ConnextFlg = true;
                    firstConnectFlg = false;
                    warnLabel.Text = "DJ-X100接続済み";
                }
                else
                {
                    warnLabel.Text = "接続失敗";
                }
                return;
            }
            if (response.Equals("\r\nOK\r\n"))
            {
                return;
            }

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
            serialPort.Close();
            MessageBox.Show("再接続する場合はDJ-X100を再起動してください", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            warnLabel.Text = "接続していません";
            connectBtn.Text = "接続";
            msgOutputBtn.Text = "メッセージ出力開始";
            msgOutputBtn.Enabled = false;
            firstConnectFlg = true;

        }

        private async void MsgOutputBtn_Click(object sender, EventArgs e)
        {
            if (msgOutputBtn.Text.Equals("メッセージ出力終了") && serialPort.IsOpen)
            {
                CloseConnection();
                return;
            }

            msgOutputBtn.Text = "メッセージ出力終了";

            var open = Encoding.ASCII.GetBytes(DJ_X100_OPEN);
            await serialPort.BaseStream.WriteAsync(open, 0, open.Length);
            await Task.Delay(100);

            var thru = Encoding.ASCII.GetBytes("AL~THRU\r");
            await serialPort.BaseStream.WriteAsync(thru, 0, thru.Length);
        }



        // COMポート一覧の初期化処理
        private void InitComPort()
        {
            String[] portList = SerialPort.GetPortNames();

            foreach (String portName in portList)
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
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
            Application.Exit();
        }

        private void ログクリアCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logTextBox.ResetText();
        }
    }


}
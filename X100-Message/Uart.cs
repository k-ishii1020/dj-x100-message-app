using System.IO.Ports;
using System.Text;

namespace X100_Message
{
    public class Uart
    {
        private SerialPort serialPort;

        private ManualResetEvent mre = new ManualResetEvent(false);
        private string response = "";

        // 基本コマンド
        private static string PREFIX = "AL~";
        private static string EOL = "\r";



        public bool InitSerialPort(String portNum)
        {
            // COMポートの設定
            var portName = portNum;
            var baudRate = 9600;
            var dataBits = 8;
            var parity = Parity.None;
            var stopBits = StopBits.One;

            serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
            serialPort.DtrEnable = true;
            serialPort.RtsEnable = true;

            try
            {
                serialPort.Open();
                serialPort.DataReceived += SerialPort_DataReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show("接続エラーが発生しました: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serialPort.Close();
                return false;
            }
            return true;
        }


        public string SendCmd(String cmd)
        {
            var sendCmd = Encoding.ASCII.GetBytes(PREFIX + cmd + EOL);
            serialPort.BaseStream.WriteAsync(sendCmd, 0, sendCmd.Length);

            mre.Reset();
            response = "";
            bool eventSet = mre.WaitOne(3000);

            if (!eventSet)
            {
                if(cmd.Equals(Command.DSPTHRU))
                {
                    MessageBox.Show("誓約してください", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "誓約していない";
                }
                MessageBox.Show("タイムアウトが発生しました", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return response;
        }

        public string SendRawCmd(String cmd)
        {
            var sendRawCmd = Encoding.ASCII.GetBytes(cmd);
            serialPort.BaseStream.WriteAsync(sendRawCmd, 0, sendRawCmd.Length);

            // Reset the event and clear the response
            mre.Reset();
            response = "";

            // Wait for the event to be set in the DataReceived event handler
            mre.WaitOne();

            // Return the response
            return response;
        }

        public bool IsOpen()
        {
            return serialPort.IsOpen;
        }

        public void Close()
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        public static String[] GetPortLists()
        {
            String[] portList = SerialPort.GetPortNames();
            Array.Sort(portList);
            return portList;
        }

        public event EventHandler<DataReceivedEventArgs> DataReceived;

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var serialPort = (SerialPort)sender;
            var buffer = new byte[serialPort.BytesToRead];
            var bytesRead = serialPort.Read(buffer, 0, buffer.Length);
            var responce = Encoding.GetEncoding("Shift_JIS").GetString(buffer, 0, bytesRead);

            // Set the response
            response = responce;

            // Signal that the response has been received
            mre.Set();

            DataReceived?.Invoke(this, new DataReceivedEventArgs(responce));
        }
    }
    public class DataReceivedEventArgs : EventArgs
    {
        public string Data { get; }

        public DataReceivedEventArgs(string data)
        {
            Data = data;
        }
    }
}

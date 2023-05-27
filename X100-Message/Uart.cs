using System.IO.Ports;
using System.Text;

namespace X100_Message
{
    public class Uart
    {
        private SerialPort serialPort;

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
                SendCmd(Command.WHO);
            }
            catch (Exception ex)
            {
                MessageBox.Show("接続エラーが発生しました: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                serialPort.Close();
                return false;
            }
            return true;
        }


        public void SendCmd(String cmd)
        {
            var sendCmd = Encoding.ASCII.GetBytes(PREFIX + cmd + EOL);
            serialPort.BaseStream.WriteAsync(sendCmd, 0, sendCmd.Length);
        }

        public void SendRawCmd(String cmd)
        {
            var sendRawCmd = Encoding.ASCII.GetBytes(cmd);
            serialPort.BaseStream.WriteAsync(sendRawCmd, 0, sendRawCmd.Length);
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

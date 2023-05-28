using System.Runtime.InteropServices;
using System.Text;

namespace X100_Message
{
    public static class IniFileHandler
    {
        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string defaultVal, StringBuilder retVal, int size, string filePath);

        public static void WriteValue(string section, string key, string value, string filePath)
        {
            WritePrivateProfileString(section, key, value, filePath);
        }

        public static string ReadValue(string section, string key, string filePath)
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", temp, 255, filePath);
            return temp.ToString();
        }
    }
}

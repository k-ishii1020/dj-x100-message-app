using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X100_Message
{
    internal class Extend
    {
        public bool IsExtendAccept(object sender)
        {
            String action = ((ToolStripMenuItem)sender).Name;

            switch(action) {
                case "ext1EnableBtn":
                    {
                        MessageBox.Show("工事中です。\n某無線雑誌をお買い求めの上有効化願います。", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return true;
                    }
                case "ext1DisableBtn":
                    {
                        return isAccept("拡張機能関連の操作も自己責任です。\nよろしいですか？\n(拡張機能2も無効になります)");
                    }
                case "ext2EnableBtn":
                    {
                        return isAccept("拡張機能関連の操作も自己責任です。\nよろしいですか？\n(初期ファームのみ有効化可能です)");
                    }
                case "ext2DisableBtn":
                    {
                        return isAccept("拡張機能関連の操作も自己責任です。\nよろしいですか？");
                    }
            }
            return false;
        } 

        private bool isAccept(string msg)
        {
            return MessageBox.Show(msg, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes;
        }
    }
}

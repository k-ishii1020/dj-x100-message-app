
namespace X100_Message
{
    public class Command
    {
        // 送信コマンド
        public const string PREPARE_MEMORY_WRITE = "DJ-X100";
        public const string WHO = "WHO";
        public const string RESTART = "RESTART";
        public const string OUTLINE = "THRU";
        public const string OUTLINE_QUIT = "QUIT";
        public const string VER = "VER";

        public const string DSPTHRU = "DSPTHRUvr";

        public const string EXT1_IS_VAILD = "EXT1";
        public const string EXT1_DISABLE = "EXT10";
        
        public const string EXT2_IS_VAILD = "EXT2";
        public const string EXT2_ENABLE = "EXT21";
        public const string EXT2_DISABLE = "EXT20";

        public const string KEYS = "KEYS";
        public const string FUNC = KEYS + "FUNC";
        public const string KEY_0 = KEYS + "0";

        //受信コマンド
        public const string OK = "OK";
        public const string NG = "NG";
        public const string ENABLE = "0001";
        public const string DISABLE = "0000";
    }
}

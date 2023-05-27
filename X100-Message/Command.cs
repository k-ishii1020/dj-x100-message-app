
namespace X100_Message
{
    public class Command
    {
        public const string PREPARE_MEMORY_WRITE = "DJ-X100"; // 書き込み準備
        public const string WHO = "WHO";
        public const string RESTART = "RESTART";
        public const string OUTLINE = "THRU";
        public const string OUTLINE_QUIT = "QUIT";
        public const string VER = "VER";

        public const string EXT1_IS_VAILD = "EXT1";
        public const string EXT1_DISABLE = "EXT10";
        
        public const string EXT2_IS_VAILD = "EXT2";
        public const string EXT2_ENABLE = "EXT21";
        public const string EXT2_DISABLE = "EXT20";
    }
}

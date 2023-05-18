namespace kmfe.Common
{
    public static class AppInfo
    {
        public const string fullName = "san11 pk2.2 多功能修改器";
        public const string shortName = "kmfe";
        public const string author = "氕氘氚";
        public const int major = 0;
        public const int minor = 1;
        public const int patch = 0;
        public const string date = "2023.4.6";
        public const string dateCode = "230406";
        public const string suffix = "alpha";

        public static readonly string shortVersion = $"{major}.{minor}.{patch}";
        public static readonly string versionName = $"{major}.{minor}.{patch}.{dateCode}" + (suffix.Length > 0 ? $"_{suffix}" : "");
        public static readonly string shortNameVersion = $"{shortName} {shortVersion}";
    }
}

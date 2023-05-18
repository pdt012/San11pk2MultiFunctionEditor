using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Linq;

namespace kmfe.Common
{
    public static class Settings
    {
        public static string Pk2Path { get; set; } = "";
        public static string PkPath { get; set; } = "";

        public static void Save(string settingsFilePath = Constants.PATH_SETTINGS)
        {
            JsonObject json = new()
            {
                { "Pk2Path", Pk2Path },
                { "PkPath", PkPath }
            };
            string str = json.ToJsonString(new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(settingsFilePath, str);

        }

        public static void Load(string settingsFilePath = Constants.PATH_SETTINGS)
        {
            JsonNode? node = null;
            try
            {
                using (FileStream fileStream = File.OpenRead(settingsFilePath))
                {
                    node = JsonNode.Parse(fileStream);
                }
            }
            catch (IOException) { }
            Pk2Path = node?["Pk2Path"]?.ToString() ?? "";
            PkPath = node?["PkPath"]?.ToString() ?? "";
        }

        public static void FromJsonString(string jsonStr)
        {
            JsonNode? node = JsonNode.Parse(jsonStr);
            Pk2Path = node?["Pk2Path"]?.ToString() ?? "";
            PkPath = node?["PkPath"]?.ToString() ?? "";
        }
    }
}

using System.Text.Json;
using System.Text.Json.Nodes;

namespace kmfe.common
{
    public class Settings
    {
        string Pk2Path { get; set; } = "";
        string PkPath { get; set; } = "";

        public string ToJsonString()
        {
            JsonObject json = new()
            {
                { "Pk2Path", Pk2Path },
                { "PkPath", PkPath }
            };
            return json.ToJsonString(new JsonSerializerOptions() { WriteIndented = true });
        }

        public void FromJsonString(string jsonStr)
        {
            JsonNode? node = JsonNode.Parse(jsonStr);
            Pk2Path = node?["Pk2Path"]?.ToString() ?? string.Empty;
            PkPath = node?["PkPath"]?.ToString() ?? string.Empty;
        }



    }
}

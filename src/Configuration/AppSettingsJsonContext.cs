using System.Text.Json.Serialization;
using FurBuilder.Configuration;

namespace FurBuilder.Data
{
    [JsonSourceGenerationOptions(
        WriteIndented = true)]
    [JsonSerializable(typeof(AppSettings))]
    internal partial class AppSettingsJsonContext : JsonSerializerContext
    {
    }
}

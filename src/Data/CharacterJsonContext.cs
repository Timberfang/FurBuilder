using System.Text.Json.Serialization;

namespace FurBuilder.Data
{
    [JsonSourceGenerationOptions(
        WriteIndented = true,
        UseStringEnumConverter = true)]
    [JsonSerializable(typeof(Character))]
    internal partial class CharacterJsonContext : JsonSerializerContext
    {
    }
}

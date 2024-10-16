using System.Text.Json.Serialization;

namespace FurBuilder.Data
{
    [JsonSourceGenerationOptions(
        WriteIndented = true,
        UseStringEnumConverter = true)]
    [JsonSerializable(typeof(ICharacter))]
    internal partial class CharacterJsonContext : JsonSerializerContext
    {
    }
}

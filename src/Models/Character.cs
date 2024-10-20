using System.Text.Json;
using System.Text.Json.Serialization;

namespace FurBuilder.Models
{
	[JsonSourceGenerationOptions(
	WriteIndented = true,
	UseStringEnumConverter = true)]
	[JsonSerializable(typeof(Character))]
	internal partial class CharacterJsonContext : JsonSerializerContext
	{
	}

	public class Character : ICharacter
	{
		public ICharacterMetadata Metadata { get; set; } = new CharacterMetadata();
		public ICharacterBasicInfo BasicInfo { get; set; } = new CharacterBasicInfo();
		public IList<ICharacterAppearance> Forms { get; set; } = [];
		public IList<string> Personality { get; set; } = [];
		public string Background { get; set; } = "";
		public string Notes { get; set; } = "";

		public override string ToString()
		{
			throw new NotImplementedException();
		}
		public string ToJson()
		{
			return JsonSerializer.Serialize(this, CharacterJsonContext.Default.Character);
		}
		public string ToMarkdown()
		{
			throw new NotImplementedException();
		}
	}
}

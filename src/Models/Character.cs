using System.Text.Json;
using System.Text.Json.Serialization;
using FurBuilder.Configuration;

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
		public ICharacterMetadata Metadata { get; set; }
		public ICharacterBasicInfo BasicInfo { get; set; } = new CharacterBasicInfo();
		public IList<ICharacterAppearance> Forms { get; set; } = [];
		public IList<string> Personality { get; set; } = [];
		public string Background { get; set; } = "";
		public string Notes { get; set; } = "";

		public Character(IOwnerData OwnerData, string SpeciesName = "", string FormName = "")
		{
			Metadata = new CharacterMetadata(OwnerData.Name);
			BasicInfo.Species = SpeciesName;
			Forms.Add(new CharacterAppearance(FormName));
		}

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

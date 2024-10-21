using System.Text;
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
			StringBuilder Output = new();

			// Basic Info
			Output.AppendLine("[blue]BASIC INFO[/]");
			Output.AppendLine($"Name: {ToStringOrDefault(BasicInfo.Name, "")}");
			Output.AppendLine($"Species: {ToStringOrDefault(BasicInfo.Species, "")}");
			Output.AppendLine($"Gender: {ToStringOrDefault(BasicInfo.Gender, "")}");
			Output.AppendLine($"Age: {ToStringOrDefault(BasicInfo.Age, 0)}");
			Output.AppendLine();
			
			Output.AppendLine("[blue]APPEARANCE[/]");
			if (Forms.Count == 1)
			{
				Output.AppendLine($"Description: {ToStringOrDefault(Forms[0].Description, "")}");
				Output.AppendLine($"Build: {ToStringOrDefault(Forms[0].Build, "")}");
				Output.AppendLine($"Height: {ToStringOrDefault(Forms[0].Height, 0)}");
				Output.AppendLine($"Weight: {ToStringOrDefault(Forms[0].Weight, 0)}");
				Output.AppendLine();
				Output.AppendLine($"Colors:");
				Output.AppendLine(DictionaryToString(Forms[0].Colors));
			}
			Output.AppendLine();

			Output.AppendLine("[blue]PERSONALITY[/]");
			Output.AppendLine(ListToString(Personality));
			Output.AppendLine();

			Output.AppendLine("[blue]BACKSTORY[/]");
			Output.AppendLine(ToStringOrDefault(Background, ""));

			return Output.ToString();
		}
		public string ToJson()
		{
			return JsonSerializer.Serialize(this, CharacterJsonContext.Default.Character);
		}
		public string ToMarkdown()
		{
			throw new NotImplementedException();
		}

		private static string DictionaryToString(IDictionary<string, string> Dictionary)
		{
			if (Dictionary.Count == 0) { return "- (Not Set)"; }
			StringBuilder Output = new();
			foreach (string Key in Dictionary.Keys) { Output.AppendLine($"- {Key}: {Dictionary[Key]}"); }
			return Output.ToString();
		}

		private static string ListToString(IList<string> List)
		{
			if (List.Count == 0) { return "- (Not Set)"; }
			StringBuilder Output = new();
			foreach (string ListItem in List) { Output.AppendLine($"- {ListItem}"); }
			return Output.ToString();
		}

		private static string ToStringOrDefault(string Property, string Default)
		{
			if (Property != Default) { return Property.ToString() ?? "Not Set"; }
			else { return "Not Set"; }
		}
		
		private static string ToStringOrDefault(int Property, int Default)
		{
			if (Property != Default) { return Property.ToString(); }
			else { return "Not Set"; }
		}

		private static string ToStringOrDefault(float Property, float Default)
		{
			if (Property != Default) { return Property.ToString(); }
			else { return "Not Set"; }
		}
	}
}

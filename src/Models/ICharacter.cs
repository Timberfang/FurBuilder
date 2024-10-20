namespace FurBuilder.Models
{
	public interface ICharacter
	{
		ICharacterMetadata Metadata { get; }
		ICharacterBasicInfo BasicInfo { get; }
		IList<ICharacterAppearance> Forms { get; set; }
		IList<string> Personality { get; set; }
		string Background { get; set; }
		string Notes { get; set; }

		public string ToString();
		public string ToJson();
		public string ToMarkdown();
	}
}

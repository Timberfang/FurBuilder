namespace FurBuilder.Models
{
	public record CharacterBasicInfo : ICharacterBasicInfo
	{
		public string ProfileImage { get; set; } = "";
		public string Name { get; set; } = "";
		public string Species { get; set; } = "";
		public string Gender { get; set; } = "";
		public int Age { get; set; }
	}
}

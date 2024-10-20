namespace FurBuilder.Models
{
	public interface ICharacterBasicInfo
	{
		string ProfileImage { get; set; }
		string Name { get; set; }
		string Species { get; set; }
		string Gender { get; set; }
		int Age { get; set; }
	}
}

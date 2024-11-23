namespace FurBuilder.Models.Character;

public class BasicAttributes(string name = "", string species = "", string gender = "", int age = 0) : IBasicAttributes
{
	public string Name { get; set; } = name;
	public string Species { get; set; } = species;
	public string Gender { get; set; } = gender;
	public int Age { get; set; } = age;

	public override string ToString()
	{
		return $"{Name} ({Species}, {Gender}, {Age})";
	}
}

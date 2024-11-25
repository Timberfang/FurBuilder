namespace FurBuilder.Models.Character;

internal class BasicAttributes(string name = "", string species = "", string gender = "", int age = 0) : IBasicAttributes
{
	private int _age = age;

	public string Name { get; set; } = name;
	public string Species { get; set; } = species;
	public string Gender { get; set; } = gender;
	public int Age
	{
		get => _age;
		set => _age = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(Age), "Age cannot be negative.");
	}
	public override string ToString()
	{
		return $"{Name} ({Species}, {Gender}, {Age})";
	}
}

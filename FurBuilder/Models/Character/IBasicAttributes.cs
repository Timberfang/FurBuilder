namespace FurBuilder.Models.Character;

internal interface IBasicAttributes
{
	internal string Name { get; set; }
	internal string Species { get; set; }
	internal string Gender { get; set; }
	internal int Age { get; set; }

	internal string ToString();
}

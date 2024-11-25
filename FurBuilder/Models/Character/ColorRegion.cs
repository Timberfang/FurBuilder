namespace FurBuilder.Models.Character;

internal class ColorRegion(string name, string region)
{
	public string Name { get; set; } = name;
	public string Region { get; set; } = region;

	public override string ToString() => $"{Name}: {Region}";
}

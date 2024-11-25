namespace FurBuilder.Models.Character;

internal interface IPhysicalAttributes
{
	internal float Height { get; set; }
	internal float Weight { get; set; }
	internal string Build { get; set; }
	internal IList<ColorRegion> Colors { get; set; }
	internal IList<string> Features { get; set; }
	internal IList<string> Clothes { get; set; }

	internal string ToString();
}

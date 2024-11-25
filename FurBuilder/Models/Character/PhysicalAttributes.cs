using System.Text;

namespace FurBuilder.Models.Character;

internal class PhysicalAttributes : IPhysicalAttributes
{
	private float _height;
	private float _weight;

	public float Height
	{
		get => _height;
		set => _height = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(Height), "Height cannot be negative.");
	}
	public float Weight
	{
		get => _weight;
		set => _weight = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(Weight), "Weight cannot be negative.");
	}
	public string Build { get; set; }
	public IList<ColorRegion> Colors { get; set; }
	public IList<string> Features { get; set; }
	public IList<string> Clothes { get; set; }

	public PhysicalAttributes(
		float height = 0,
		float weight = 0,
		string build = "",
		IList<ColorRegion>? colors = null,
		IList<string>? features = null,
		IList<string>? clothes = null)
	{
		Height = height;
		Weight = weight;
		Build = build;
		Colors = colors ?? new List<ColorRegion>();
		Features = features ?? new List<string>();
		Clothes = clothes ?? new List<string>();
	}

	public override string ToString()
	{
		StringBuilder output = new();
		output.AppendLine($"Height: {(Height > 0 ? Height : "Unknown")}");
		output.AppendLine($"Weight: {(Weight > 0 ? Weight : "Unknown")}");
		output.AppendLine($"Build: {(Build != "" ? Build : "Unknown")}");
		output.AppendLine("Colors: ");
		output.Append(Colors.Count > 0 ? string.Join(", ", Colors) : "None");
		output.AppendLine("Features: ");
		output.Append(Features.Count > 0 ? string.Join(", ", Features) : "None");
		output.AppendLine("Clothes: ");
		output.Append(Clothes.Count > 0 ? string.Join(", ", Clothes) : "None");
		return output.ToString();
	}
}

using System.Text;

namespace FurBuilder.Models.Character;

internal class PhysicalAttributes(
	float height = 0,
	float weight = 0,
	string build = "",
	IList<Color>? colors = null,
	IList<string>? features = null,
	IList<string>? clothes = null) : IPhysicalAttributes
{
	public float Height { get; set; } = height;
	public float Weight { get; set; } = weight;
	public string Build { get; set; } = build;
	public IList<Color> Colors { get; set; } = colors ?? new List<Color>();
	public IList<string> Features { get; set; } = features ?? new List<string>();
	public IList<string> Clothes { get; set; } = clothes ?? new List<string>();

	public override string ToString()
	{
		StringBuilder output = new();
		output.AppendLine($"Height: {Height}");
		output.AppendLine($"Weight: {Weight}");
		output.AppendLine($"Build: {Build}");
		output.AppendLine("Colors:");
		output.Append(string.Join(", ", Colors));
		output.AppendLine("Features:");
		output.Append(string.Join(", ", Features));
		output.AppendLine("Clothes:");
		output.Append(string.Join(", ", Clothes));
		return output.ToString();
	}
}

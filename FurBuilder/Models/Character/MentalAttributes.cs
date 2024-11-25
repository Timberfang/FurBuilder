using System.Text;

namespace FurBuilder.Models.Character;

internal class MentalAttributes(
	IList<string>? traits = null,
	IList<string>? likes = null,
	IList<string>? dislikes = null,
	string backstory = "") : IMentalAttributes
{
	public IList<string> Traits { get; set; } = traits ?? new List<string>();
	public IList<string> Likes { get; set; } = likes ?? new List<string>();
	public IList<string> Dislikes { get; set; } = dislikes ?? new List<string>();
	public string Backstory { get; set; } = backstory;

	public override string ToString()
	{
		StringBuilder output = new();
		output.AppendLine("Traits:");
		output.Append(string.Join(", ", Traits));
		output.AppendLine("Likes:");
		output.Append(string.Join(", ", Likes));
		output.AppendLine("Dislikes:");
		output.Append(string.Join(", ", Dislikes));
		output.AppendLine($"Backstory: {Backstory}");
		return output.ToString();
	}
}

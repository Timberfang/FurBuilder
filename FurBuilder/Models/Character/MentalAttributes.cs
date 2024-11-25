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
		output.Append("Traits:");
		output.AppendLine(Traits.Count > 0 ? string.Join(", ", Traits) : "None");
		output.Append("Likes:");
		output.AppendLine(Likes.Count > 0 ? string.Join(", ", Likes) : "None");
		output.Append("Dislikes:");
		output.AppendLine(Dislikes.Count > 0 ? string.Join(", ", Dislikes) : "None");
		output.AppendLine($"Backstory: {Backstory}");
		return output.ToString();
	}
}

namespace FurBuilder.Models.Character;

internal interface IMentalAttributes
{
	internal IList<string> Traits { get; set; }
	internal IList<string> Likes { get; set; }
	internal IList<string> Dislikes { get; set; }
	internal string Backstory { get; set; }

	internal string ToString();
}

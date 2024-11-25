namespace FurBuilder.Models.Character;

internal interface IMentalAttributes
{
	IList<string> Traits { get; set; }
	IList<string> Likes { get; set; }
	IList<string> Dislikes { get; set; }
	string Backstory { get; set; }

	internal string ToString();
}

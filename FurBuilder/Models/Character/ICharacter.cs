namespace FurBuilder.Models.Character;

internal interface ICharacter
{
	internal IMetadata Metadata { get; set; }
	internal IBasicAttributes BasicAttributes { get; set; }
	internal IPhysicalAttributes PhysicalAttributes { get; set; }
	internal IMentalAttributes MentalAttributes { get; set; }

	internal string ToString();
	internal string ToMarkup();
	internal string ToMarkdown();
	internal string ToJson();
}

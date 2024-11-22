namespace FurBuilder.Models.Character;

internal class Character(
	IMetadata? metadata = null,
	IBasicAttributes? basicAttributes = null,
	IPhysicalAttributes? physicalAttributes = null,
	IMentalAttributes? mentalAttributes = null)
	: ICharacter
{
	public IMetadata Metadata { get; set; } = metadata ?? new Metadata();
	public IBasicAttributes BasicAttributes { get; set; } = basicAttributes ?? new BasicAttributes();
	public IPhysicalAttributes PhysicalAttributes { get; set; } = physicalAttributes ?? new PhysicalAttributes();
	public IMentalAttributes MentalAttributes { get; set; } = mentalAttributes ?? new MentalAttributes();

	public string ToString(bool singleLine = false)
	{
		throw new NotImplementedException();
	}

	public string ToMarkdown()
	{
		throw new NotImplementedException();
	}

	public string ToJson()
	{
		throw new NotImplementedException();
	}
}

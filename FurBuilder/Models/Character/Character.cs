using System.Text;

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

	public override string ToString()
	{
		StringBuilder output = new();
		output.AppendLine("METADATA");
		output.AppendLine();
		output.AppendLine(Metadata.ToString());
		output.AppendLine();
		output.AppendLine();
		output.AppendLine("BASIC ATTRIBUTES");
		output.AppendLine();
		output.AppendLine(BasicAttributes.ToString());
		output.AppendLine();
		output.AppendLine();
		output.AppendLine("PHYSICAL ATTRIBUTES");
		output.AppendLine();
		output.AppendLine(PhysicalAttributes.ToString());
		output.AppendLine();
		output.AppendLine();
		output.AppendLine("MENTAL ATTRIBUTES");
		output.AppendLine();
		output.AppendLine(MentalAttributes.ToString());
		return output.ToString();
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

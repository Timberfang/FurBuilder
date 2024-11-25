namespace FurBuilder.Models.Character;

internal class Metadata(string owner = "") : IMetadata
{
	public string Owner { get; set; } = owner;
	public Guid Guid { get; } = Guid.NewGuid();
	public DateTime DateCreated { get; set; } = DateTime.Now;

	public override string? ToString()
	{
		return $"Owner: {(Owner != "" ? Owner : "Unknown")}, DateCreated: {DateCreated}";
	}
}

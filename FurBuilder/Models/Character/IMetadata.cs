namespace FurBuilder.Models.Character;

internal interface IMetadata
{
	internal string Owner { get; set; }
	internal Guid Guid { get; }
	internal DateTime DateCreated { get; set; }

	internal string? ToString();
}

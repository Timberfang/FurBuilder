namespace FurBuilder.Models
{
	public interface ICharacterMetadata
	{
		Guid Id { get; }
		string Owner { get; set; }
		DateTime CreatedAt { get; }
	}
}

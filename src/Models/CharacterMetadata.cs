namespace FurBuilder.Models
{
	public record CharacterMetadata : ICharacterMetadata
	{
		public Guid Id { get; } = Guid.NewGuid();
		public string Owner { get; set; }
		public DateTime CreatedAt { get; } = DateTime.Now;

		public CharacterMetadata(string Owner = "")
		{
			this.Owner = Owner;
		}
	}
}

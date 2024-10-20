namespace FurBuilder.Data
{
    public record CharacterMetadata : ICharacterMetadata
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Owner { get; set; } = "";
        public DateTime CreatedAt { get; } = DateTime.Now;
    }
}

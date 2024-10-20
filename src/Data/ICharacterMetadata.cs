namespace FurBuilder.Data
{
    public interface ICharacterMetadata
    {
        Guid Id { get; }
        string Owner { get; set; }
        DateTime CreatedAt { get; }
    }
}

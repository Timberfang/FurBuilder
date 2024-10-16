namespace FurBuilder.Configuration
{
    public interface IOwnerData
    {
        public bool Configured { get; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

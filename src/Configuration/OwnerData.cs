namespace FurBuilder.Configuration
{
    public class OwnerData : IOwnerData
    {
        public bool Configured { get { return Name != "" && Email != ""; } }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
    }
}

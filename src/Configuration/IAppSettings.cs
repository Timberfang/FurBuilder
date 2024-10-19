namespace FurBuilder.Configuration
{
    public interface IAppSettings
    {
        public OwnerData Owner { get; set; }

        public void Set();
    }
}

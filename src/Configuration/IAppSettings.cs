namespace FurBuilder.Configuration
{
    public interface IAppSettings
    {
        public IOwnerData Owner { get; set; }

        public void Set();
    }
}

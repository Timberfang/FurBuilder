namespace FurBuilder.Configuration
{
	internal interface IAppSettings
	{
		public OwnerData Owner { get; set; }
		public void Set();
	}
}

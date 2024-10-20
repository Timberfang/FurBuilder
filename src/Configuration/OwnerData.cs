namespace FurBuilder.Configuration
{
	public record OwnerData
	{
		public bool Configured { get { return Name != "" && Email != ""; } }
		public string Name { get; set; } = "";
		public string Email { get; set; } = "";
	}
}

namespace FurBuilder.Models
{
	public record CharacterAppearance : ICharacterAppearance
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public IDictionary<string, string> Colors { get; set; } = new Dictionary<string, string>();
		public string Build { get; set; } = "";
		public float Height { get; set; } // In centimeters
		public float Weight { get; set; } // In kilograms

		public CharacterAppearance(string Name = "Base", string Description = "")
		{
			this.Name = Name;
			this.Description = Description;
		}
	}
}

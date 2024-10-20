namespace FurBuilder.Models
{
	public interface ICharacterAppearance
	{
		string Name { get; set; }
		string Description { get; set; }
		IDictionary<string, string> Colors { get; set; }
		string Build { get; set; }
		float Height { get; set; } // In centimeters
		float Weight { get; set; } // In kilograms
	}
}

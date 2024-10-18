namespace FurBuilder.Data
{
    public interface IAppearance
    {
        string Name { get; set; } // Name the form (e.g. "Werewolf Form", "Human Form", etc.); use "Base" if there is only one form.
        string Description { get; set; } // Describe the appearance in this form (e.g. "A tall, muscular wolf-like humanoid")
        IDictionary<string, string> Colors { get; set; } // Key for body part (eyes, fur, hair, skin, etc.), value for color.
        string Build { get; set; }
        float Height { get; set; } // In centimeters
        float Weight { get; set; } // In kilograms
        IList<string> PhysicalFeatures { get; set; } // Scars, markings, facial features, etc.
    }
}

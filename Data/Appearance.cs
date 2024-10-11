
namespace FurBuilder.Data
{
    public class Appearance : IAppearance
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IDictionary<string, string> Colors { get; set; }
        public string Build { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public IList<string> PhysicalFeatures { get; set; }

        public Appearance(string Name, string Description = "", IDictionary<string, string>? Colors = null, string Build = "", float Height = 0, float Weight = 0, IList<string>? PhysicalFeatures = null)
        {
            this.Name = Name;
            this.Description = Description;
            this.Colors = Colors ?? new Dictionary<string, string>();
            this.Build = Build;
            this.Height = Height;
            this.Weight = Weight;
            this.PhysicalFeatures = PhysicalFeatures ?? [];
        }
    }
}

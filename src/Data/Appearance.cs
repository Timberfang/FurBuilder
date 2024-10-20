using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurBuilder.Data
{
    public record Appearance : IAppearance
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public IDictionary<string, string> Colors { get; set; } = new Dictionary<string, string>();
        public string Build { get; set; } = "";
        public float Height { get; set; } // In centimeters
        public float Weight { get; set; } // In kilograms
    }
}

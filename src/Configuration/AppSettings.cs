using System.Text.Json;
using FurBuilder.Data;
using Microsoft.Extensions.Configuration;

namespace FurBuilder.Configuration
{
    public class AppSettings : IAppSettings
    {
        private readonly string SettingsFilePath = Path.Join(Environment.CurrentDirectory, "appsettings.json");
        public IOwnerData Owner { get; set; } = new OwnerData();
        public class OwnerData : IOwnerData
        {
            public bool Configured { get { return Name != "" && Email != ""; } }
            public string Name { get; set; } = "";
            public string Email { get; set; } = "";
        }

        public AppSettings()
        {
            IConfigurationBuilder Builder = new ConfigurationBuilder().AddJsonFile(SettingsFilePath);
            Builder.Build().Bind(this);
        }

        public void Set()
        {
            File.WriteAllText(SettingsFilePath, JsonSerializer.Serialize(this, AppSettingsJsonContext.Default.AppSettings));
        }
    }
}

using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;

namespace FurBuilder.Configuration
{
	[JsonSourceGenerationOptions(
	WriteIndented = true)]
	[JsonSerializable(typeof(AppSettings))]
	internal partial class AppSettingsJsonContext : JsonSerializerContext
	{
	}

	public class AppSettings : IAppSettings
	{
		private readonly string SettingsFilePath = Path.Join(Environment.CurrentDirectory, "appsettings.json");
		public OwnerData Owner { get; set; } = new OwnerData(); // Use OwnerData instead of IOwnerData to prevent AOT compilation warning:
																// "Cannot create instance of type 'FurBuilder.Configuration.IOwnerData' because it is missing a public instance constructor."
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

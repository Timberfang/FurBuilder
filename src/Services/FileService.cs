using FurBuilder.Models;

namespace FurBuilder.Services
{
	internal static class FileService
	{
		private static readonly string TargetDirectory = Path.Join(Environment.CurrentDirectory, "Characters");
		internal static bool Exists(string Name) { return Path.Exists(Path.Join(TargetDirectory, Name)); }
		internal static void Save(ICharacter Character, string Name) { File.WriteAllText(Path.Join(TargetDirectory, $"{Name}.json"), Character.ToJson()); }
	}
}
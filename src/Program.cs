using FurBuilder.Configuration;

namespace FurBuilder
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CLI.Interactive.InteractiveMenu.InteractiveStart(new AppSettings());
		}
	}
}

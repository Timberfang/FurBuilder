using FurBuilder.Models.Character;

using Spectre.Console;

namespace FurBuilder.Views.ConsoleView;

internal static class MainMenu
{
	internal static void Start()
	{
		Console.WriteLine("Welcome to FurBuilder!");
		Console.WriteLine();
		Console.WriteLine("Let's make a character.");
		Console.ReadLine();

		BasicAttributes characterAttributes = new(
			AnsiConsole.Ask<string>("Character name:"),
			AnsiConsole.Ask<string>("Character species:"),
			AnsiConsole.Ask<string>("Character gender:"),
			AnsiConsole.Ask<int>("Character age:")
		);

		Character currentCharacter = new(basicAttributes: characterAttributes);
		Console.WriteLine("Here's your character so far:");
		Console.Write(currentCharacter.ToString());
	}
}

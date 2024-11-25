using FurBuilder.Models.Character;

using Spectre.Console;

namespace FurBuilder.Views.ConsoleView;

internal static class MainMenu
{
	internal static void Start()
	{
		AnsiConsole.WriteLine("Welcome to FurBuilder!");
		AnsiConsole.WriteLine();
		AnsiConsole.MarkupLine("[blue]Let's make a character.[/]");
		AnsiConsole.WriteLine();
		AnsiConsole.MarkupLine("[blue]First, we'll need some basic information. Please answer each question below; type enter to submit your response.[/]");

		Metadata characterMetadata = new(AnsiConsole.Ask<string>("Your name or preferred alias; this tracks who owns the character:"));
		BasicAttributes characterAttributes = new(
			AnsiConsole.Ask<string>("Character name:"),
			AnsiConsole.Ask<string>("Character species:"),
			AnsiConsole.Ask<string>("Character gender:"),
			AnsiConsole.Prompt(
				new TextPrompt<int>("Character age (enter only a positive number):")
					.Validate((n) => n switch
					{
						< 0 => ValidationResult.Error("Age cannot be negative."),
						0 => ValidationResult.Error("Age cannot be zero."),
						> 0 => ValidationResult.Success()
					})
			)
		);

		Character currentCharacter = new(characterMetadata, characterAttributes);
		AnsiConsole.WriteLine("Here's your character so far:");
		AnsiConsole.WriteLine();
		AnsiConsole.MarkupLine(currentCharacter.ToMarkup());

		if (AnsiConsole.Prompt(new ConfirmationPrompt("Would you like to continue filling out this character? (This isn't implemented yet!)")))
		{
			throw new NotImplementedException();
		}
		else
		{
			AnsiConsole.WriteLine("See you later!");
			Environment.Exit(0);
		}
	}
}

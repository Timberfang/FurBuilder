using System.Net.Mail;
using FurBuilder.Configuration;
using Spectre.Console;

namespace FurBuilder.CLI.Interactive
{
	internal static class InteractiveMenu
	{
		// Set of all valid menu options
		private enum MenuOption
		{
			CreateCharacter,
			ViewCharacter,
			EditCharacter,
			ListCharacters,
			DeleteCharacter,
			Exit
		}

		// Used for displaying to the user; Combines above with user-friendly labels
		private static readonly Dictionary<string, MenuOption> MenuOptionDict = new()
		{
			{ "Create Character", MenuOption.CreateCharacter },
			{ "View Character", MenuOption.ViewCharacter },
			{ "Edit Character", MenuOption.EditCharacter },
			{ "List Characters", MenuOption.ListCharacters },
			{ "Delete Character", MenuOption.DeleteCharacter },
			{ "Exit", MenuOption.Exit }
		};

		// Load or create relevant configuration data
		internal static void InteractiveStart(IAppSettings Settings)
		{
			if (Settings.Owner.Configured)
			{
				AnsiConsole.MarkupLine($"[blue]Welcome to FurBuilder, {Settings.Owner.Name}![/]");
				AnsiConsole.WriteLine();
				ShowMainMenu(Settings);
			}
			else
			{
				AnsiConsole.MarkupLine($"[blue]Welcome to FurBuilder! It seems we couldn't find any data for your user, so let's create it.[/]");
				Settings.Owner.Name = AnsiConsole.Ask<string>("First, what's a good name we can call you by?");
				Settings.Owner.Email = new MailAddress(AnsiConsole.Ask<string>("Second, how about your email address?")).Address; // We use string because MailAddress doesn't work right with Spectre.Console; It always returns "Invalid input".
				Settings.Set();
				AnsiConsole.WriteLine();
				ShowMainMenu(Settings);
			}
		}

		// Display main menu
		private static void ShowMainMenu(IAppSettings Settings)
		{
			MenuOption SelectedOption;

			do
			{
				SelectedOption = MenuOptionDict[AnsiConsole.Prompt(new SelectionPrompt<string>()
					.Title("Choose an option using the arrow keys, then press enter.")
					.AddChoices(MenuOptionDict.Keys))];

				switch (SelectedOption)
				{
					case MenuOption.CreateCharacter:
						throw new NotImplementedException();
					case MenuOption.ViewCharacter:
						throw new NotImplementedException();
					case MenuOption.EditCharacter:
						throw new NotImplementedException();
					case MenuOption.ListCharacters:
						throw new NotImplementedException();
					case MenuOption.DeleteCharacter:
						throw new NotImplementedException();
					case MenuOption.Exit:
						Environment.Exit(0);
						break;
					default:
						throw new ArgumentOutOfRangeException($"Unrecognized menu option {SelectedOption}");
				};
			} while (SelectedOption != MenuOption.Exit);
		}
	}
}

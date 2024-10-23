using System.Net.Mail;
using FurBuilder.Configuration;
using FurBuilder.Models;
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
		private static readonly Dictionary<MenuOption, string> MenuOptionDict = new()
		{
			{ MenuOption.CreateCharacter, "Create Character" },
			{ MenuOption.ViewCharacter, "View Character" },
			{ MenuOption.EditCharacter, "Edit Character" },
			{ MenuOption.ListCharacters, "List Characters" },
			{ MenuOption.DeleteCharacter, "Delete Character" },
			{ MenuOption.Exit, "Exit" }
		};

		private enum CreateOption
		{
			Name,
			Species,
			Gender,
			Age,
			Appearance,
			Personality,
			Backstory,
			Exit
		}

		private static readonly Dictionary<CreateOption, string> CreateOptionDict = new()
		{
			{ CreateOption.Name, "Name" },
			{ CreateOption.Species, "Species" },
			{ CreateOption.Gender, "Gender" },
			{ CreateOption.Age, "Age" },
			{ CreateOption.Appearance, "Appearance" },
			{ CreateOption.Personality, "Personality" },
			{ CreateOption.Backstory, "Backstory" },
			{ CreateOption.Exit, "Exit" }
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
				SelectedOption = AnsiConsole.Prompt(
					new SelectionPrompt<MenuOption>()
						.UseConverter(Choice => MenuOptionDict[Choice])
						.AddChoices(MenuOptionDict.Keys)
						.Title("Choose an option using the arrow keys, then press enter.")
				);

				switch (SelectedOption)
				{
					case MenuOption.CreateCharacter:
						CreateCharacter(Settings.Owner);
						break;
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

		private static ICharacter CreateCharacter(IOwnerData Data)
		{
			CreateOption SelectedOption;
			ICharacter NewCharacter = new Character(Data);

			do
			{
				AnsiConsole.Clear();
				AnsiConsole.MarkupLine(NewCharacter.ToString());
				SelectedOption = AnsiConsole.Prompt(
					new SelectionPrompt<CreateOption>()
						.UseConverter(Choice => CreateOptionDict[Choice])
						.AddChoices(CreateOptionDict.Keys)
						.Title("Choose an option using the arrow keys, then press enter."));

				switch (SelectedOption)
				{
					case CreateOption.Name:
						NewCharacter.BasicInfo.Name = UserPrompt.GetCharacterTrait<string>("Name");
						break;
					case CreateOption.Species:
						NewCharacter.BasicInfo.Species = UserPrompt.GetCharacterTrait<string>("Species");
						break;
					case CreateOption.Gender:
						NewCharacter.BasicInfo.Gender = UserPrompt.GetCharacterTrait<string>("Gender");
						break;
					case CreateOption.Age:
						NewCharacter.BasicInfo.Age = UserPrompt.GetCharacterTrait<int>("Age");
						break;
					case CreateOption.Appearance:
						// TODO: Appearance creation logic
						break;
					case CreateOption.Personality:
						// TODO: Personality creation logic
						break;
					case CreateOption.Backstory:
						// TODO: Backstory creation logic
						break; 
					case CreateOption.Exit:
						Environment.Exit(0);
						break;
					default:
						throw new ArgumentOutOfRangeException($"Unrecognized menu option {SelectedOption}");
				};
			} while (SelectedOption != CreateOption.Exit);

			return NewCharacter;
		}
	}
}

using System.Net.Mail;
using FurBuilder.Configuration;
using Spectre.Console;

namespace FurBuilder.CLI.Interactive
{
	internal static class InteractiveMenu
	{
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
		private static void ShowMainMenu(IAppSettings Settings)
		{
			const string CreateCommand = "Create character";
			const string EditCommand = "Edit character";
			const string ListCommand = "List characters";
			const string ExitCommand = "Exit";

			string UserChoice;
			do
			{
				Console.Clear();
				UserChoice = AnsiConsole.Prompt(
					new SelectionPrompt<string>()
						.Title("Choose an option using the arrow keys, then press enter to get started.")
						.AddChoices([CreateCommand, EditCommand, ListCommand, ExitCommand]));
				switch (UserChoice)
				{
					case CreateCommand:
						throw new NotImplementedException();
					case EditCommand:
						throw new NotImplementedException();
					case ListCommand:
						throw new NotImplementedException();
					case ExitCommand:
						Environment.Exit(0);
						break;
				}
			} while (UserChoice != ExitCommand);
		}
	}
}

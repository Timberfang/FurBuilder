using FurBuilder.Configuration;
using Spectre.Console;

namespace FurBuilder.CLI
{
    public static class Menu
    {
        public static void ShowOptions(IAppSettings Settings)
        {
            const string CreateCommand = "Create character";
            const string EditCommand = "Edit character";
            const string ListCommand = "List characters";
            const string ExitCommand = "Exit";

            // TODO: Add view character command
            while (true)
            {
                Console.Clear();
                string UserChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an option using the arrow keys, then press enter to get started.")
                        .AddChoices([CreateCommand, EditCommand, ListCommand, ExitCommand]));
                switch (UserChoice)
                {
                    case CreateCommand:
                        Commands.NewCharacter(Settings);
                        break;
                    case EditCommand:
                        Commands.EditCharacter();
                        break;
                    case ListCommand:
                        Commands.ListCharacter();
                        break;
                    case ExitCommand:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}

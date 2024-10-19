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
                    // Create command here
                    Commands.NewCharacter(Settings);
                    break;
                case EditCommand:
                    // Edit command here
                    break;
                case ListCommand:
                    // List command here
                    break;
                    case ExitCommand:
                        Environment.Exit(0);
                    break;
            }
        }
    }
}
}

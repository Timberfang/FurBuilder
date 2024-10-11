using Spectre.Console;

namespace FurBuilder.CLI
{
    public static class ConsoleMenu
    {
        public static void ShowOptions()
        {
            const string CreateCommand = "Create character";
            const string EditCommand = "Edit character";
            const string ListCommand = "List characters";

            string UserChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Welcome to FurBuilder! Choose an option using the arrow keys, then press enter to get started.")
                    .AddChoices([CreateCommand, EditCommand, ListCommand]));
            switch (UserChoice)
            {
                case CreateCommand:
                    // Create command here
                    Commands.Create.NewCharacter();
                    break;
                case EditCommand:
                    // Edit command here
                    break;
                case ListCommand:
                    // List command here
                    break;
                default:
                    break;
            }
        }
    }
}

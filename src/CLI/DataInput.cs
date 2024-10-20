using System.Text;
using System.Text.Json;
using FurBuilder.Data;
using RadLine;
using Spectre.Console;

namespace FurBuilder.CLI
{
    internal class DataInput
    {
        private static readonly string CharacterDirectory = Path.Join(Environment.CurrentDirectory, "Characters");

        // Get a file path from the user
        internal static string GetFilePath(string Prompt)
        {
            while (true)
            {
                string FilePath = PromptUser<string>(Prompt);

                if (!Path.Exists(FilePath))
                {
                    Console.WriteLine();
                    AnsiConsole.MarkupLine("[red]That path doesn't exist![/] Please choose another name.");
                    Console.WriteLine();
                }
                else
                {
                    return FilePath;
                }
            }
        }

        // Retrieve a character from a JSON file
        internal static ICharacter? GetCharacter(string Prompt)
        {
            if (Directory.Exists(CharacterDirectory))
            {
                string[] Files = Directory.GetFiles(CharacterDirectory, "*.json");
                if (Files.Length > 0)
                {
                    // Convert path to name for the menu
                    List<string> UserFriendlyFileNames = [];
                    foreach (string File in Files) { UserFriendlyFileNames.Add(Path.GetFileNameWithoutExtension(File)); }

                    // Get a character file
                    string ChosenFile = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title(Prompt)
                        .AddChoices(UserFriendlyFileNames));

                    // Convert name back to path
                    ChosenFile = Directory.GetFiles(CharacterDirectory, $"{ChosenFile}" + ".json").First();
                    return JsonSerializer.Deserialize(File.ReadAllText(ChosenFile), CharacterJsonContext.Default.Character);
                }
                else { return null; }
            }
            else { return null; }
        }

        // List all character files
        internal static string? ListCharacters()
        {
            string[] Files = Directory.GetFiles(CharacterDirectory, "*.json");
            if (Files.Length > 0)
            {
                StringBuilder Output = new();
                foreach (string File in Files) { Output.AppendLine(Path.GetFileNameWithoutExtension(File)); }
                return Output.ToString();
            }
            else { return null; }
        }

        // Save a character to a JSON file
        internal static void SaveCharacter(string Prompt, ICharacter Data)
        {
            // Create character directory if it doesn't exist
            Directory.CreateDirectory(CharacterDirectory);

            // Get file name and path
            while (true)
            {
                string FileName = PromptUser<string>(Prompt);
                string OutputPath = Path.Join(CharacterDirectory, $"{FileName}.json");
                
                // Save file if it doesn't exist
                if (Path.Exists(OutputPath))
                {
                    Console.WriteLine();
                    AnsiConsole.MarkupLine("[red]That file already exists![/] Please choose another name.");
                    Console.WriteLine();
                }
                else
                {
                    File.WriteAllText(OutputPath, Data.ToJson());
                    Console.WriteLine();
                    Console.Write("Character file written at: ");
                    Console.Write(OutputPath);
                    Console.WriteLine();
                    break;
                }
            }
        }

        // Get a boolean from the user
        internal static bool PromptUserYesNo(string Prompt)
        {
            return AnsiConsole.Prompt(new SelectionPrompt<string>().Title(Prompt).AddChoices(["Yes", "No"])) == "Yes";
        }

        // Create a list from user input
        internal static IList<string> PromptUserForList(string Prompt, string AttributeLabel)
        {
            Console.WriteLine();
            AnsiConsole.MarkupLine(Prompt);
            Console.WriteLine();
            return NewAttributeList(AttributeLabel);
        }

        // Create a dictionary from user input
        internal static IDictionary<string, string> PromptUserForDictionary(string Prompt, string KeyLabel, string AttributeLabel)
        {
            Console.WriteLine();
            AnsiConsole.MarkupLine(Prompt);
            Console.WriteLine();
            return NewDictionary(KeyLabel, AttributeLabel);
        }

        // Get generic input from the user. Just a wrapper at the moment, but could be more later.
        internal static Type PromptUser<Type>(string Prompt)
        {
            return AnsiConsole.Prompt(new TextPrompt<Type>(Prompt));
        }
        internal static Type PromptUser<Type>(string Prompt, Type CurrentValue)
        {
            Console.WriteLine("Press enter with an empty prompt to retain the existing value (shown in parentheses)");
            Console.WriteLine();
            return AnsiConsole.Prompt(new TextPrompt<Type>(Prompt).DefaultValue(CurrentValue));
        }

        // Get a multi-line string from the user
        internal async static Task<string> PromptUserMultiLine(string Prompt)
        {
            Console.WriteLine();
            AnsiConsole.MarkupLine(Prompt);
            AnsiConsole.MarkupLine("[blue]Press SHIFT+ENTER to insert a new line, and press ENTER to submit.[/]");
            Console.WriteLine();
            LineEditor Editor = new() { MultiLine = true };

            return await Editor.ReadLine(CancellationToken.None) ?? "";
        }

        // Backend logic for list creation
        private static List<string> NewAttributeList(string Label)
        {
            Console.WriteLine($"Enter one '{Label}' attribute at a time, and then press enter. When done, type 'exit', and press enter.");
            List<string> Output = [];

            while (true)
            {
                string UserInput = PromptUser<string>($"'{Label}' Attribute:");
                if (UserInput == "exit") { break; }
                else { Output.Add(UserInput); }
            }

            return Output;
        }

        // Backend logic for dictionary creation
        private static Dictionary<string, string> NewDictionary(string KeyLabel, string ValueLabel)
        {
            Dictionary<string, string> Output = [];

            Console.WriteLine("Enter the requested data on each line. When done, type 'exit', and press enter.");
            while (true)
            {
                string Key = PromptUser<string>($"{KeyLabel}:");
                if (Key == "exit") { break; }
                string Value = PromptUser<string>($"{ValueLabel}:");
                if (Value == "exit") { break; }
                Output.Add(Key, Value);
            }

            return Output;
        }
    }
}

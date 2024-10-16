using FurBuilder.Data;
using Spectre.Console;

namespace FurBuilder.CLI
{
    internal class DataInput
    {
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

        internal static void SaveFile(string Prompt, Character Data)
        {
            while (true)
            {
                string FileName = PromptUser<string>(Prompt);
                string OutputPath = Path.Join(Environment.CurrentDirectory, $"{FileName}.json");

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

        internal static bool PromptUserYesNo(string Prompt)
        {
            return AnsiConsole.Prompt(new SelectionPrompt<string>().Title(Prompt).AddChoices(["Yes", "No"])) == "Yes";
        }

        internal static IList<string> PromptUserForList(string Prompt, string AttributeLabel)
        {
            Console.WriteLine();
            AnsiConsole.MarkupLine(Prompt);
            Console.WriteLine();
            return NewAttributeList(AttributeLabel);
        }

        internal static IDictionary<string, string> PromptUserForDictionary(string Prompt, string KeyLabel, string AttributeLabel)
        {
            Console.WriteLine();
            AnsiConsole.MarkupLine(Prompt);
            Console.WriteLine();
            return NewDictionary(KeyLabel, AttributeLabel);
        }

        internal static Type PromptUser<Type>(string Prompt)
        {
            return AnsiConsole.Prompt(new TextPrompt<Type>(Prompt));
        }

        private static IDictionary<string, string> NewDictionary(string KeyLabel, string ValueLabel)
        {
            Dictionary<string, string> Output = [];

            Console.WriteLine("Enter the requested data on each line. When done, type 'exit', and press enter.");
            while (true)
            {
                string Key = PromptUser<string>($"{KeyLabel}:");
                if (Key == "exit") { break; }
                string Value = PromptUser<string>($"{ValueLabel}");
                if (Value == "exit") { break; }
                Output.Add(Key, Value);
            }

            return Output;
        }

        private static IList<string> NewAttributeList(string Label)
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
    }
}

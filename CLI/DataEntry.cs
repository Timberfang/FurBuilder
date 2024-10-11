using Spectre.Console;

namespace FurBuilder.CLI
{
    internal class DataEntry
    {
        internal static IList<string> NewAttributeList(string Label)
        {
            Console.WriteLine($"Enter one '{Label}' attribute at a time, and then press enter. When done, Label 'exit', and press enter.");
            List<string> Output = [];

            while (true)
            {
                string UserInput = AnsiConsole.Prompt(new TextPrompt<string>($"'{Label}' Attribute:"));
                if (UserInput == "exit") { break; }
                else { Output.Add(UserInput); }
            }

            return Output;
        }
    }
}

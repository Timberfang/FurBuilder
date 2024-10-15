using FurBuilder.Data;
using Spectre.Console;

namespace FurBuilder.CLI.Commands
{
    public class Create
    {
        public static void NewCharacter()
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[blue]Welcome to FurBuilder![/]");
            Console.WriteLine();
            Console.WriteLine("Let's create a character.");

            string OwnerInput = AnsiConsole.Prompt(new TextPrompt<string>("First, who's the owner of this character? If you're the owner, just enter your name:"));
            string NameInput = AnsiConsole.Prompt(new TextPrompt<string>("Great! How about the character's name?"));
            string SpeciesInput = AnsiConsole.Prompt(new TextPrompt<string>("Now, what species is your character?"));

            Character WorkingCharacter = new(OwnerInput, NameInput, SpeciesInput);
            Console.WriteLine();
            AnsiConsole.MarkupLine("[blue]Now we have the basics out of the way.[/]");
            Console.WriteLine();
            Console.WriteLine($"So your character is named '{WorkingCharacter.Name}', their species is '{WorkingCharacter.Species}', and the owner's name is '{WorkingCharacter.Owner}'.");
            Console.WriteLine($"For reference, your character's unique ID is '{WorkingCharacter.Id}'.");
            Console.WriteLine();

            if (PromptUserYesNo("Do you have a profile picture ready for your character? It's not necessary, so we can still proceed without it."));
            {
                // ProfileImage logic here
            }

            WorkingCharacter.Gender = PromptUser<string>("What's your character's gender?");
            WorkingCharacter.Age = PromptUser<int>("How old is your character, in years?");

            int NumberOfForms = 1;
            if (PromptUserYesNo("Is your character a shapeshifter of some kind? That is, do they have more than one form?"))
            {
                // ShapeShifter logic here - get number of forms, then set number of loops for form creation
            }

            for (int i = 1; i <= NumberOfForms; i++)
            {
                if (NumberOfForms == 1)
                {
                    WorkingCharacter.Forms.Add(new Appearance("Base")
                    {
                        Description = PromptUser<string>("Please briefly describe your character's appearance, in one to three sentences:"),
                        // Colors logic here
                        Build = PromptUser<string>("What build does your character have? For example, 'muscular', 'average', 'athletic', or 'chubby':"),
                        Height = PromptUser<float>("What's your character's height, in centimeters?"),
                        Weight = PromptUser<float>("What's your character's weight, in kilograms?"),
                        PhysicalFeatures = PromptUserForList($"[blue]Let's give {WorkingCharacter.Name} some physical features![/]", "Physical Feature")
                    });
                }
            }

            WorkingCharacter.Personality = PromptUserForList($"[blue]Let's give {WorkingCharacter.Name} some personality traits![/]", "Personality Trait");

            // Background logic here - use Radline

            if (PromptUserYesNo("Would you like to add any notes to your character sheet?")) { WorkingCharacter.Notes = PromptUser<string>("Enter the notes for your character:"); }

            SaveFile("What do you want to name the character sheet file? For example, 'John Doe' would output a file called 'John Doe.json'.", WorkingCharacter);
        }

        private static void SaveFile(string Prompt, Character Data)
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

        private static bool PromptUserYesNo(string Prompt)
        {
            return AnsiConsole.Prompt(new SelectionPrompt<string>().Title(Prompt).AddChoices(["Yes", "No"])) == "Yes";
        }

        private static IList<string> PromptUserForList(string Prompt, string AttributeLabel)
        {
            Console.WriteLine();
            AnsiConsole.MarkupLine(Prompt);
            Console.WriteLine();
            return DataEntry.NewAttributeList(AttributeLabel);
        }

        private static Type PromptUser<Type>(string Prompt)
        {
            return AnsiConsole.Prompt(new TextPrompt<Type>(Prompt));
        }
    }
}

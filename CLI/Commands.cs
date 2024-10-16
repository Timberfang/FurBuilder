using FurBuilder.Data;
using FurBuilder.CLI;
using Spectre.Console;

namespace FurBuilder.CLI
{
    internal class Commands
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

            if (DataInput.PromptUserYesNo("Do you have a profile picture ready for your character? It's not necessary, so we can still proceed without it."))
            {
                WorkingCharacter.ProfileImage = DataInput.GetFilePath("Please enter the path to your profile picture file:");
            }

            WorkingCharacter.Gender = DataInput.PromptUser<string>("What's your character's gender?");
            WorkingCharacter.Age = DataInput.PromptUser<int>("How old is your character, in years?");

            int NumberOfForms = 1;
            if (DataInput.PromptUserYesNo("Is your character a shapeshifter of some kind? That is, do they have more than one form?"))
            {
                NumberOfForms = DataInput.PromptUser<int>("How many forms does your character have? Enter only a number:");
            }

            for (int i = 1; i <= NumberOfForms; i++)
            {
                if (NumberOfForms == 1)
                {
                    WorkingCharacter.Forms.Add(new Appearance("Base")
                    {
                        Description = DataInput.PromptUser<string>("Please briefly describe your character's appearance, in one to three sentences:"),
                        Colors = DataInput.PromptUserForDictionary("What colors does your character have? You can have as many as you want, using a 'Region: Color' structure.", "Region", "Color"),
                        Build = DataInput.PromptUser<string>("What build does your character have? For example, 'muscular', 'average', 'athletic', or 'chubby':"),
                        Height = DataInput.PromptUser<float>("What's your character's height, in centimeters?"),
                        Weight = DataInput.PromptUser<float>("What's your character's weight, in kilograms?"),
                        PhysicalFeatures = DataInput.PromptUserForList($"[blue]Let's give {WorkingCharacter.Name} some physical features![/]", "Physical Feature")
                    });
                }
            }

            WorkingCharacter.Personality = DataInput.PromptUserForList($"[blue]Let's give {WorkingCharacter.Name} some personality traits![/]", "Personality Trait");

            // Background logic here - use Radline

            if (DataInput.PromptUserYesNo("Would you like to add any notes to your character sheet?")) { WorkingCharacter.Notes = DataInput.PromptUser<string>("Enter the notes for your character:"); }

            DataInput.SaveFile("What do you want to name the character sheet file? For example, 'John Doe' would output a file called 'John Doe.json'.", WorkingCharacter);
        }
    }
}

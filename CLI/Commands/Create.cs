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

            bool HasProfileImage = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Do you have a profile picture ready for your character? It's not necessary, so we can still proceed without it.").AddChoices(["Yes", "No"])) == "Yes";
            if (HasProfileImage)
            {
                // ProfileImage logic here
            }

            WorkingCharacter.Gender = AnsiConsole.Prompt(new TextPrompt<string>("What's your character's gender?"));
            WorkingCharacter.Age = AnsiConsole.Prompt(new TextPrompt<int>("How old is your character, in years?"));

            int NumberOfForms = 1;
            bool IsShapeShifter = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Is your character a shapeshifter of some kind? That is, do they have more than one form?").AddChoices(["Yes", "No"])) == "Yes";
            if (IsShapeShifter)
            {
                // ShapeShifter logic here - get number of forms, then set number of loops for form creation
            }

            for (int i = 1; i <= NumberOfForms; i++)
            {
                if (NumberOfForms == 1)
                {
                    Appearance WorkingAppearance = new Appearance("Base");
                    WorkingAppearance.Description = AnsiConsole.Prompt(new TextPrompt<string>("Please briefly describe your character's appearance, in one to three sentences:"));
                    // Colors logic here
                    WorkingAppearance.Build = AnsiConsole.Prompt(new TextPrompt<string>("What build does your character have? For example, 'muscular', 'average', 'athletic', or 'chubby':"));
                    WorkingAppearance.Height = AnsiConsole.Prompt(new TextPrompt<float>("What's your character's height, in centimeters?"));
                    WorkingAppearance.Weight = AnsiConsole.Prompt(new TextPrompt<float>("What's your character's weight, in kilograms?"));
                    Console.WriteLine();
                    AnsiConsole.MarkupLine($"[blue]Let's give {WorkingCharacter.Name} some physical features![/]");
                    Console.WriteLine();
                    WorkingAppearance.PhysicalFeatures = DataEntry.NewAttributeList("Physical Feature");
                    WorkingCharacter.Forms.Add(WorkingAppearance);
                }
            }

            Console.WriteLine();
            AnsiConsole.MarkupLine($"[blue]Let's give {WorkingCharacter.Name} some personality traits![/]");
            Console.WriteLine();
            WorkingCharacter.Personality = DataEntry.NewAttributeList("Personality Trait");
            // Background logic here - use Radline
            // Notes logic here
        }
    }
}

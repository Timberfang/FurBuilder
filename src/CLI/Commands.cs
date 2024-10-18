using FurBuilder.Data;
using Spectre.Console;
using FurBuilder.Configuration;

namespace FurBuilder.CLI
{
    internal class Commands
    {
        public static void NewCharacter(IAppSettings Settings)
        {
            Console.Clear();
            Console.WriteLine("Let's create a character.");

            Character WorkingCharacter = new Character(Settings.Owner.Name);
            WorkingCharacter = SetAttributes(WorkingCharacter);
        }

        public static void EditCharacter(IAppSettings Settings)
        {
            // TODO: Add editing logic; List all character files (json format), get name without suffix, pick one, deserialize to ICharacter, modify with SetAttributes.
        }

        private static Character SetAttributes(Character WorkingCharacter)
        {
            // TODO: Find a better way to handle this.
            Console.WriteLine("Your character's appearance is stored under 'forms'.");

            while (true)
            {
                // Set menu choices
                IList<string> Choices = [];
                foreach (ConfigurableAttribute Attribute in WorkingCharacter.ConfigurableAttributes)
                {
                    if (Attribute.Configured) { Choices.Add(Attribute.Name); }
                    else { Choices.Add(Attribute.Name + " (Not Set)"); }
                }
                Choices.Add("Save Character");
                Choices.Add("Exit");

                // Display menu
                string UserChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an attribute to edit, 'Save Character' to save to a file, or 'Exit' to return to the previous menu:")
                        .AddChoices(Choices));

                // Take action
                switch (UserChoice.Replace(" (Not Set)", ""))
                {
                    case "Profile Image":
                        WorkingCharacter.ProfileImage = DataInput.GetFilePath("Enter the path to your profile picture file:");
                        break;
                    case "Name":
                        WorkingCharacter.Name = DataInput.PromptUser<string>("Enter your character's name:");
                        break;
                    case "Species":
                        WorkingCharacter.Species = DataInput.PromptUser<string>("Enter your character's species:");
                        break;
                    case "Gender":
                        WorkingCharacter.Gender = DataInput.PromptUser<string>("Enter your character's gender:");
                        break;
                    case "Age":
                        WorkingCharacter.Age = DataInput.PromptUser<int>("Enter your character's age, in years. Enter only a number:");
                        break;
                    case "Forms":
                        if (WorkingCharacter.Forms.Count == 0)
                        {
                            int NumberOfForms = 1;
                            if (DataInput.PromptUserYesNo("Is your character a shapeshifter of some kind? That is, do they have more than one form?"))
                            {
                                NumberOfForms = DataInput.PromptUser<int>("How many forms does your character have? Enter only a number:");
                            }
                            WorkingCharacter.Forms = CreateAppearance(NumberOfForms);
                        }
                        else { EditAppearance(WorkingCharacter.Forms); }
                        break;
                    case "Personality":
                        WorkingCharacter.Personality = DataInput.PromptUserForList($"[blue]Let's give {WorkingCharacter.Name} some personality traits![/]", "Personality Trait");
                        break;
                    case "Background":
                        WorkingCharacter.Background = DataInput.PromptUserMultiLine("Describe your character's backstory:").Result;
                        break;
                    case "Notes":
                        WorkingCharacter.Notes = DataInput.PromptUser<string>("Enter the any notes you want for your character:");
                        break;
                    case "Save Character":
                        DataInput.SaveFile("What do you want to name the character sheet file? For example, 'John Doe' would output a file called 'John Doe.json'.", WorkingCharacter);
                        break;
                    case "Exit":
                        return WorkingCharacter;
                }
            }
        }
        
        private static IList<IAppearance> CreateAppearance(int NumberOfForms)
        {
            IList<IAppearance> Output = [];
            for (int i = 1; i <= NumberOfForms; i++)
            {
                if (NumberOfForms == 1)
                {
                    Output.Add(new Appearance("Base")
                    {
                        Description = DataInput.PromptUser<string>("Briefly describe your character's appearance, in one to three sentences:"),
                        Colors = DataInput.PromptUserForDictionary("What colors does your character have? You can have as many as you want, using a 'Region: Color' structure.", "Region", "Color"),
                        Build = DataInput.PromptUser<string>("What build does your character have? For example, 'muscular', 'average', 'athletic', or 'chubby':"),
                        Height = DataInput.PromptUser<float>("What's your character's height, in centimeters?"),
                        Weight = DataInput.PromptUser<float>("What's your character's weight, in kilograms?"),
                        PhysicalFeatures = DataInput.PromptUserForList($"[blue]Let's give your character some physical features![/]", "Physical Feature")
                    });
                }
                else
                {
                    string FormName = DataInput.PromptUser<string>($"What's the name of form #{i} of your character? For example, this could be 'Human', 'Werewolf', 'Base', or any other name you'd like.");
                    Output.Add(new Appearance(FormName)
                    {
                        Description = DataInput.PromptUser<string>($"Briefly describe your character's appearance in their '{FormName}' form, in one to three sentences:"),
                        Colors = DataInput.PromptUserForDictionary("What colors does this form of your character have? You can have as many as you want, using a 'Region: Color' structure.", "Region", "Color"),
                        Build = DataInput.PromptUser<string>("What build does your character have in this form? For example, 'muscular', 'average', 'athletic', or 'chubby':"),
                        Height = DataInput.PromptUser<float>("What's your character's height in this form, in centimeters?"),
                        Weight = DataInput.PromptUser<float>("What's your character's weight in this form, in kilograms?"),
                        PhysicalFeatures = DataInput.PromptUserForList($"[blue]Let's give your character some physical features for their {FormName} form![/]", "Physical Feature")
                    });
                }
            }
            return Output;
        }

        private static IList<IAppearance> EditAppearance(IList<IAppearance> WorkingAppearance)
        {
            // TODO: Create editing logic
            return WorkingAppearance;
        }
    }
}

using FurBuilder.Configuration;
using FurBuilder.Data;
using Spectre.Console;

namespace FurBuilder.CLI
{
    internal class Commands
    {
        public static void NewCharacter(IAppSettings Settings)
        {
            Console.Clear();
            Console.WriteLine("Let's create a character.");

            ICharacter WorkingCharacter = SetAttributes(new Character(Settings.Owner.Name));

            if (DataInput.PromptUserYesNo("Do you want to save your character?"))
            {
                DataInput.SaveCharacter(
                    "What do you want to name the character sheet file? For example, 'John Doe' would output a file called 'John Doe.json'.",
                    WorkingCharacter);
            }
        }

        public static void EditCharacter()
        {
            // TODO: List character's current attributes in each section when selected
            // TODO: Give option to cancel editing
            // TODO: Give option to pick individual components of lists and dictionaries for editing.
            Console.Clear();

            ICharacter? WorkingCharacter = DataInput.GetCharacter("Choose a character file to edit:");
            if (WorkingCharacter != null) { SetAttributes(WorkingCharacter); }
            else
            {
                AnsiConsole.MarkupLine("[red]No character files found![/] Please create a character before trying to edit one.");
            }
        }

        public static void ListCharacter()
        {
            Console.Clear();

            AnsiConsole.MarkupLine("[blue]Character List[/]");
            Console.WriteLine();
            Console.WriteLine(DataInput.ListCharacters() ?? "No characters found");
            Console.WriteLine("Press enter to return to the previous menu...");
            Console.ReadLine();
        }

        private static ICharacter SetAttributes(ICharacter WorkingCharacter)
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
                Choices.Add("Exit");

                // Display menu
                string UserChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an attribute to edit, then choose 'Exit' when done to return to the previous menu:")
                        .AddChoices(Choices));

                // If user exits, no data preparation required
                if (UserChoice == "Exit") { return WorkingCharacter; }
                else
                {
                    // Get whether attribute is configured
                    bool AttributeConfigured = !UserChoice.Contains("Not Set");

                    // Take action
                    switch (UserChoice.Replace(" (Not Set)", ""))
                    {
                        case "Profile Image":
                            if (AttributeConfigured) { WorkingCharacter.ProfileImage = DataInput.PromptUser<string>("Enter your character's name:", WorkingCharacter.ProfileImage); }
                            else { WorkingCharacter.ProfileImage = DataInput.GetFilePath("Enter the path to your profile picture file:"); }
                            break;
                        case "Name":
                            if (AttributeConfigured) { WorkingCharacter.Name = DataInput.PromptUser<string>("Enter your character's name:", WorkingCharacter.Name); }
                            else { WorkingCharacter.Name = DataInput.PromptUser<string>("Enter your character's name:"); }
                            break;
                        case "Species":
                            if (AttributeConfigured) { WorkingCharacter.Species = DataInput.PromptUser<string>("Enter your character's species:", WorkingCharacter.Species); }
                            else { WorkingCharacter.Species = DataInput.PromptUser<string>("Enter your character's species:"); }
                            break;
                        case "Gender":
                            if (AttributeConfigured) { WorkingCharacter.Gender = DataInput.PromptUser<string>("Enter your character's gender:", WorkingCharacter.Gender); }
                            else { WorkingCharacter.Gender = DataInput.PromptUser<string>("Enter your character's gender:"); }
                            break;
                        case "Age":
                            if (AttributeConfigured) { WorkingCharacter.Age = DataInput.PromptUser<int>("Enter your character's gender:", WorkingCharacter.Age); }
                            else { WorkingCharacter.Age = DataInput.PromptUser<int>("Enter your character's age, in years. Enter only a number:"); }
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
                            if (AttributeConfigured) { Console.WriteLine(GetCurrentValue(UserChoice, WorkingCharacter.Background)); }
                            WorkingCharacter.Background = DataInput.PromptUserMultiLine("Describe your character's backstory:").Result;
                            break;
                        case "Notes":
                            if (AttributeConfigured) { WorkingCharacter.Notes = DataInput.PromptUser<string>("Enter your character's gender:", WorkingCharacter.Notes); }
                            else { WorkingCharacter.Notes = DataInput.PromptUser<string>("Enter the any notes you want for your character:"); }
                            break;
                    }
                }
            }
        }

        private static IList<Appearance> CreateAppearance(int NumberOfForms)
        {
            IList<Appearance> Output = [];
            for (int i = 1; i <= NumberOfForms; i++)
            {
                if (NumberOfForms == 1)
                {
                    Output.Add(new Appearance("Base")
                    {
                        Description = DataInput.PromptUser<string>("Briefly describe your character's appearance, in one to three sentences:"),
                        Colors = DataInput.PromptUserForDictionary("What colors does your character have? You can have as many as you want, using a 'Region: Color' structure.", "Region", "Color"),
                        Build = DataInput.PromptUser<string>("What build does your character have? For example, 'Muscular', 'Average', 'Athletic', or 'Chubby':"),
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
                        Build = DataInput.PromptUser<string>("What build does your character have in this form? For example, 'Muscular', 'Average', 'Athletic', or 'Chubby':"),
                        Height = DataInput.PromptUser<float>("What's your character's height in this form, in centimeters?"),
                        Weight = DataInput.PromptUser<float>("What's your character's weight in this form, in kilograms?"),
                        PhysicalFeatures = DataInput.PromptUserForList($"[blue]Let's give your character some physical features for their {FormName} form![/]", "Physical Feature")
                    });
                }
            }
            return Output;
        }

        private static IList<Appearance> EditAppearance(IList<Appearance> WorkingAppearance)
        {
            // TODO: Create editing logic
            return WorkingAppearance;
        }
    }
}

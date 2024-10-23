using Spectre.Console;

namespace FurBuilder.CLI.Interactive
{
	internal static class UserPrompt
	{
		internal static Type GetCharacterTrait<Type> (string TraitName)
		{
			return AnsiConsole.Ask<Type>($"Enter your character's {TraitName}:");
		}

		internal static IList<string> GetTraitList (string TraitName, bool DisplayList = false)
		{
			List<string> Output = [];
			while (true)
			{
				Console.Clear();
				if (DisplayList)
				{
					AnsiConsole.WriteLine($"{TraitName} List:");
					if (Output.Count == 0) { AnsiConsole.WriteLine("- (Empty)"); }
					else
					{
						foreach (string ListItem in Output)
						{
							AnsiConsole.WriteLine($"- {ListItem}");
						}
					}
					AnsiConsole.WriteLine();
				}

				string UserInput = AnsiConsole.Ask<string>($"Enter a trait of type '{TraitName}', or type 'exit' to exit:");
				if (!UserInput.Equals("exit", StringComparison.OrdinalIgnoreCase)) { Output.Add(UserInput); }
				else { break; }
			}
			return Output;
		}
	}
}
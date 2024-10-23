using Spectre.Console;

namespace FurBuilder.CLI.Interactive
{
	internal static class UserPrompt
	{
		internal static Type GetCharacterTrait<Type> (string TraitName)
		{
			return AnsiConsole.Ask<Type>($"Enter your character's {TraitName}:");
		}
	}
}
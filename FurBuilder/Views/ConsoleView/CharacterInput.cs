using FurBuilder.Models.Character;

using Spectre.Console;

namespace FurBuilder.Views.ConsoleView;

internal static class CharacterInput
{
	private enum ListOption
	{
		Add,
		Replace,
		Remove,
		Exit
	}
	private static readonly Dictionary<ListOption, string> ListOptionLabels = new() {
		{ ListOption.Add, "Add item" },
		{ ListOption.Replace, "Replace item" },
		{ ListOption.Remove, "Remove item" },
		{ ListOption.Exit, "Exit" }
	};

	internal static IList<string> NewListString(string label = "")
	{
		List<string> output = [];
		if (label != "") { AnsiConsole.WriteLine($"Creating a list of '{label}' objects."); }
		else { AnsiConsole.WriteLine("Creating a list of objects."); }

		while (true)
		{
			AnsiConsole.WriteLine($"{label} list:");
			if (output.Count == 0) { AnsiConsole.WriteLine("- None"); }
			else { foreach (string listItem in output) { AnsiConsole.WriteLine($"- {listItem}"); } }

			ListOption chosenAction = AnsiConsole.Prompt(
				new SelectionPrompt<ListOption>()
					.Title("Select one of the options below:")
					.UseConverter(x => ListOptionLabels[x])
					.AddChoices(ListOptionLabels.Keys)
			);

			switch (chosenAction)
			{
				case ListOption.Add:
					output.Add(AnsiConsole.Ask<string>($"Enter a '{label}' item:"));
					break;
				case ListOption.Replace:
					if (output.Count == 0) { AnsiConsole.MarkupLine("[red]There are no items in the list to replace![/]"); }
					else
					{
						int traitIndex = GetListIndex(output);
						output[traitIndex] = AnsiConsole.Ask<string>($"Enter a '{label}' item:");
					}
					break;
				case ListOption.Remove:
					if (output.Count == 0) { AnsiConsole.MarkupLine("[red]There are no items in the list to remove![/]"); }
					else
					{
						int traitIndex = GetListIndex(output);
						output.RemoveAt(traitIndex);
					}
					break;
				case ListOption.Exit:
					return output;
			}
		}
	}

	internal static IList<ColorRegion> NewListColor(string label = "ColorRegion")
	{
		List<ColorRegion> output = [];
		if (label != "") { AnsiConsole.WriteLine($"Creating a list of '{label}' objects."); }
		else { AnsiConsole.WriteLine("Creating a list of objects."); }

		while (true)
		{
			AnsiConsole.WriteLine($"{label} list:");
			if (output.Count == 0) { AnsiConsole.WriteLine("- None"); }
			else { foreach (ColorRegion listItem in output) { AnsiConsole.WriteLine($"- {listItem}"); } }

			ListOption chosenAction = AnsiConsole.Prompt(
				new SelectionPrompt<ListOption>()
					.Title("Select one of the options below:")
					.UseConverter(x => ListOptionLabels[x])
					.AddChoices(ListOptionLabels.Keys)
			);

			switch (chosenAction)
			{
				case ListOption.Add:
					output.Add(new ColorRegion(AnsiConsole.Ask<string>("ColorRegion:"), AnsiConsole.Ask<string>("Region:")));
					break;
				case ListOption.Replace:
					if (output.Count == 0) { AnsiConsole.MarkupLine("[red]There are no items in the list to replace![/]"); }
					else
					{
						int traitIndex = GetListIndex(output);
						output[traitIndex].Name = AnsiConsole.Ask<string>("Color:");
						output[traitIndex].Region = AnsiConsole.Ask<string>("Region:");
					}
					break;
				case ListOption.Remove:
					if (output.Count == 0) { AnsiConsole.MarkupLine("[red]There are no items in the list to remove![/]"); }
					else
					{
						int traitIndex = GetListIndex(output);
						output.RemoveAt(traitIndex);
					}
					break;
				case ListOption.Exit:
					return output;
			}
		}
	}

	private static int GetListIndex(IList<string> input)
	{
		return AnsiConsole.Prompt(
			new SelectionPrompt<int>()
				.Title("Select one of the options below:")
				.UseConverter(x => input[x])
				.AddChoices(Enumerable.Range(0, input.Count))
		);
	}

	private static int GetListIndex(IList<ColorRegion> input)
	{
		return AnsiConsole.Prompt(
			new SelectionPrompt<int>()
				.Title("Select one of the options below:")
				.UseConverter(x => input[x].ToString())
				.AddChoices(Enumerable.Range(0, input.Count))
		);
	}
}

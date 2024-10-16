using System.Net.Mail;
using FurBuilder.Configuration;
using Spectre.Console;

namespace FurBuilder.CLI
{
    internal static class Startup
    {
        internal static void StartProcess(IAppSettings Settings)
        {
            if (Settings.Owner.Configured)
            {
                AnsiConsole.MarkupLine($"[blue]Welcome to FurBuilder, {Settings.Owner.Name}![/]");
                Console.WriteLine();
                Menu.ShowOptions(Settings);
            }
            else
            {
                AnsiConsole.MarkupLine($"[blue]Welcome to FurBuilder! It seems we couldn't find any data for your user, so let's create it.[/]");
                Settings.Owner.Name = DataInput.PromptUser<string>("First, what's a good name we can call you by?");
                Settings.Owner.Email = new MailAddress(DataInput.PromptUser<string>("Second, how about your email address?")).Address; // We use string because MailAddress doesn't work right with Spectre.Console; It always returns "Invalid input".
                Settings.Set();
                Console.WriteLine();
                Menu.ShowOptions(Settings);
            }
        }
    }
}

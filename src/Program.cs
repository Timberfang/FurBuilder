using FurBuilder.CLI;
using FurBuilder.Configuration;

namespace FurBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppSettings Settings = new();
            if (args.Length > -1) { Startup.StartProcess(Settings); } // TODO: Once GUI added, change -1 to 0 here.
        }
    }
}

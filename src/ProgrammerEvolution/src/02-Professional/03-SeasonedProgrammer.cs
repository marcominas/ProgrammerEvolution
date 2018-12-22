using System;

namespace ProgrammerEvolution
{
    /// <summary>
    /// I learn about docstring advantages - to nknow more about, see:
    /// https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/xmldoc/how-to-use-the-xml-documentation-features
    /// </summary>
    class SeasonedProgrammer
    {
        /// <summary>
        /// This program allow you say hello world passing it as argument.
        /// </summary>
        /// <param name="args">A single arg or two args string with message to be printed</param>
        static void Main(string[] args)
        {
            var usage = "Usage: ProgrammerEvolution.SeasonedProgrammer.exe \"Hello World\"";

            // Now i know that "using" pattern is better and RIGHT use of args :)
            if (args.Length == 0)
            {
                Console.WriteLine(usage);
                Environment.Exit(1);
            }

            string message = string.Empty;
            if (args.Length == 1)
            {
                if (args[0].ToLower() != "hello world")
                {
                    Console.WriteLine(usage);
                    Environment.Exit(2);
                }

                message = args[0];
            }

            if (args.Length == 2)
            {
                if (args[0].ToLower() != "hello" || args[1].ToLower() != "world")
                {
                    Console.WriteLine(usage);
                    Environment.Exit(3);
                }
                message = args[0] + " " + args[1];
            }

            Console.WriteLine(message);
            // Inform success execution to System.
            Environment.Exit(0);
        }
    }
}

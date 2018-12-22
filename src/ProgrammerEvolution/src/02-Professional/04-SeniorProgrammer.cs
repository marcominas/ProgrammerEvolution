using System;

namespace ProgrammerEvolution
{
    /// <summary>
    /// I learn about docstring advantages - to nknow more about, see:
    /// https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/xmldoc/how-to-use-the-xml-documentation-features
    /// </summary>
    class SeniorProgrammer
    {
        /// <summary>
        /// This program allow you say hello world passing it as argument.
        /// </summary>
        /// <param name="args">A single arg or two args string with message to be printed</param>
        static void Main(string[] args)
        {
            // Decouple responsabilities of validate and get values of args.
            try
            {
                // single responsability - validate and throw a exception on error
                ValidateArgs(args);

                // single responsability - get value according args passed.
                var message = GetArgsValue(args);
                Console.WriteLine(message);
                // Inform success execution to System.
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Inform an error code to System.
                Environment.Exit(args.Length+ 1);
            }
        }

        /// <summary>
        /// Validate if arg is passed and value(s) is allowed.
        /// </summary>
        /// <param name="args">args passed to application</param>
        static void ValidateArgs(string[] args)
        {
            var usage = "Usage: ProgrammerEvolution.SeniorProgrammer.exe \"Hello World\"";

            // Now i know that "using" pattern is better and RIGHT use of args :)
            if (args.Length == 0)
                throw new Exception(usage);

            if (args.Length == 1 && args[0].ToLower() != "hello world")
                throw new Exception(usage);

            if (args.Length == 2 & (args[0].ToLower() != "hello" || args[1].ToLower() != "world"))
                throw new Exception(usage);

            if (args.Length > 2)
                throw new Exception(usage + " or ProgrammerEvolution.SeniorProgrammer.exe \"Hello\" \"World\"");

            Console.WriteLine("args successfully validated");
        }

        /// <summary>
        /// Get args value - validation already done.
        /// </summary>
        /// <param name="args">args passed to application</param>
        /// <returns></returns>
        static string GetArgsValue(string[] args)
        {
            string message = string.Empty;

            if (args.Length == 1)
                message = args[0];

            if (args.Length == 2)
                message = args[0] + " " + args[1];

            return message;
        }
    }
}

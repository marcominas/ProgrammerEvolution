using System;

namespace ProgrammerEvolution
{
    /// <summary>
    /// I learn about docstring advantages - to know more about, see:
    /// https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/xmldoc/how-to-use-the-xml-documentation-features
    /// </summary>
    class SoftwareEngineerLevelOne
    {
        /// <summary>
        /// This program allow you say hello world passing it as argument.
        /// </summary>
        /// <param name="args">A single arg or two args string with message to be printed</param>
        static void Main(string[] args)
        {
            try
            {
                var assembyName = "ProgrammerEvolution.SoftwareEngineerLevelOne.exe";
                var instance = new SoftwareEngineer(assembyName);

                instance.ValidateArgs(args);
                var message = instance.GetArgsValue(args);
                Console.WriteLine(message);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(args.Length + 1);
            }
        }
    }

    /// <summary>
    /// Avoid implementation without basics funcionalities
    /// </summary>
    internal interface ISoftwareEngineer
    {
        string GetArgsValue(string[] args);
        void ValidateArgs(string[] args);
    }

    /// <summary>
    /// A real implementation of a software engineer
    /// </summary>
    internal class SoftwareEngineer : ISoftwareEngineer
    {
        /// <summary>
        /// Avoid type do not writing it more than once this value 
        /// Also enhance manutenability of application.
        /// Must be setted on class initialization.
        /// </summary>
        private readonly string AssembyName;

        /// <summary>
        /// Default class constructor
        /// </summary>
        /// <param name="assembyName">Assemby name</param>
        public SoftwareEngineer(string assembyName)
        {
            this.AssembyName = assembyName;           
        }

        /// <summary>
        /// Get args value - validation already done.
        /// </summary>
        /// <param name="args">args passed to application</param>
        /// <returns></returns>
        public string GetArgsValue(string[] args)
        {
            string message = string.Empty;

            if (args.Length == 1)
                message = args[0];

            if (args.Length == 2)
                message = args[0] + " " + args[1];

            return message;
        }

        /// <summary>
        /// Validate if arg is passed and value(s) is allowed.
        /// </summary>
        /// <param name="args">args passed to application</param>
        public void ValidateArgs(string[] args)
        {
            // Now i know that "using" pattern is better and RIGHT use of args :)
            if (args.Length == 0)
                throw new Exception(this.GetDefaultErrorMessage());

            if (args.Length == 1 && args[0].ToLower() != "hello world")
                throw new Exception(this.GetDefaultErrorMessage());

            if (args.Length == 2 & (args[0].ToLower() != "hello" || args[1].ToLower() != "world"))
                throw new Exception(this.GetDefaultErrorMessage());

            if (args.Length > 2)
                throw new Exception(this.GetDefaultErrorMessage() + " or ProgrammerEvolution.Experient.exe \"Hello\" \"World\"");

            Console.WriteLine("args successfully validated");
        }

        /// <summary>
        /// Get default error messagem with assembly name.
        /// </summary>
        /// <returns></returns>
        private string GetDefaultErrorMessage()
        {
            return string.Format("Usage: {0} \"Hello World\"", this.AssembyName);
        }
    }
}

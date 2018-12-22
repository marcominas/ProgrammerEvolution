using System;

namespace ProgrammerEvolution
{
    /// <summary>
    /// I learn about docstring advantages - to know more about, see:
    /// https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/xmldoc/how-to-use-the-xml-documentation-features
    /// </summary>
    class SoftwareEngineertLevelTwo
    {
        /// <summary>
        /// This program allow you say hello world passing it as argument.
        /// </summary>
        /// <param name="args">A single arg or two args string with message to be printed</param>
        static void Main(string[] args)
        {
            try
            {
                var assembyName = "ProgrammerEvolution.SoftwareEngineerLevelTwo.exe";
                var instance = new LevelTwo.SoftwareEngineer(assembyName);

                instance.Validate(args);
                var message = instance.GetValue(args);
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
    /// Refactor to use a better code and methods names
    /// </summary>
    namespace LevelTwo
    {
        /// <summary>
        /// Avoid implementation without basics funcionalities
        /// </summary>
        internal interface ISoftwareEngineer
        {
            string GetValue(params string[] @params);
            void Validate(params string[] @params);
        }

        /// <summary>
        /// Validation Exception
        /// </summary>
        internal class ValidateException : Exception
        {
            public ValidateException(string message) : base(message) { }
        }

        /// <summary>
        /// Many args validation Exception
        /// </summary>
        internal class ManyArgsException : Exception
        {
            public ManyArgsException(string message) : base(message) { }
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
            public string GetValue(string[] args)
            {
                string message = string.Join(" ", args);
                return message;
            }

            /// <summary>
            /// Validate if arg is passed and value(s) is allowed.
            /// </summary>
            /// <param name="args">args passed to application</param>
            public void Validate(string[] args)
            {
                if (args != null && args.Length > 2)
                    throw new ManyArgsException(this.GetDefaultErrorMessage() + " or ProgrammerEvolution.Experient.exe \"Hello\" \"World\"");

                if ("hello world".Equals(this.GetValue(args), StringComparison.OrdinalIgnoreCase))
                    throw new ValidateException(this.GetDefaultErrorMessage());

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
}

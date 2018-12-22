using System;

namespace ProgrammerEvolution
{
    /// <summary>
    /// I learn about docstring advantages - to know more about, see:
    /// https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/xmldoc/how-to-use-the-xml-documentation-features
    /// </summary>
    class SoftwareEngineerLevelThree
    {
        /// <summary>
        /// This program allow you say hello world passing it as argument.
        /// </summary>
        /// <param name="args">A single arg or two args string with message to be printed</param>
        static void Main(string[] args)
        {
            try
            {
                var assembyName = "ProgrammerEvolution.SoftwareEngineerLevelThree.exe";
                var instance = new LevelThree.SoftwareEngineer(assembyName);

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
    namespace LevelThree
    {
        /// <summary>
        /// Avoid implementation without basics funcionalities
        /// </summary>
        internal interface ISoftwareEngineer
        {
            string GetValue(params string[] @params);
            void Validate(params string[] @params);
        }

        internal enum ValidationErrorType
        {
            /// <summary>
            /// None argument were specified
            /// </summary>
            NoneArgumentPassed = 1,
            /// <summary>
            /// One argument specified but it is invalid
            /// </summary>
            SingleInvalidArgumentPassed = 2,
            /// <summary>
            /// Two arguments specified but one or both are invalids
            /// </summary>
            TwoInvalidArgumentsPassed = 3,
            /// <summary>
            /// More than two arguments specified and it is now allowed
            /// </summary>
            MoreThanTwoArguments = 4
        }

        /// <summary>
        /// Validation Exception
        /// </summary>
        internal class ValidateException : Exception
        {
            /// <summary>
            /// Validation error type
            /// </summary>
            public readonly ValidationErrorType errorType;

            /// <summary>
            /// Validation exception constructor
            /// </summary>
            /// <param name="message">Error message</param>
            /// <param name="errorType">Validation error type <see cref="ValidationErrorType"/></param>
            public ValidateException(string message, ValidationErrorType errorType) : base(message)
            {
                this.errorType = errorType;
            }
        }

        /// <summary>
        /// Many args validation Exception
        /// </summary>
        internal class ManyArgsException : ValidateException
        {
            /// <summary>
            /// Validation exception constructor
            /// </summary>
            /// <param name="message">Error message</param>
            public ManyArgsException(string message) : base(message, ValidationErrorType.MoreThanTwoArguments) { }
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
            /// <param name="params">args passed to application</param>
            /// <returns></returns>
            public string GetValue(params string[] @params)
            {
                string message = string.Join(" ", @params);
                return message;
            }

            /// <summary>
            /// Validate if arg is passed and value(s) is allowed.
            /// </summary>
            /// <param name="params">args passed to application</param>
            public void Validate(params string[] @params)
            {
                if (@params != null && @params.Length > 3)
                    throw new ManyArgsException(this.GetDefaultErrorMessage() + " or ProgrammerEvolution.Experient.exe \"Hello\" \"World\"");

                if ("hello world".Equals(this.GetValue(@params), StringComparison.OrdinalIgnoreCase))
                {
                    var erroType = @params.Length == 1 ? ValidationErrorType.SingleInvalidArgumentPassed : ValidationErrorType.TwoInvalidArgumentsPassed;
                    throw new ValidateException(this.GetDefaultErrorMessage(), erroType);
                }
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

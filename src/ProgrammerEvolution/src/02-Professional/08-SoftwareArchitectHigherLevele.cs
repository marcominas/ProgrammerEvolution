using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProgrammerEvolution
{
    /// <summary>
    /// I learn about docstring advantages - to know more about, see:
    /// https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/xmldoc/how-to-use-the-xml-documentation-features
    /// </summary>
    class SoftwareArchitectHigherLevel
    {
        /// <summary>
        /// This program allow you say hello world passing it as argument.
        /// </summary>
        /// <param name="args">A single arg or two args string with message to be printed</param>
        static void Main(string[] args)
        {
            try
            {
                var assembyName = "ProgrammerEvolution.SoftwareArchitectHigherLevel.exe";
                var instance = new LevelOne.SoftwareArchitect(assembyName);

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
    namespace LevelOne
    {
        /// <summary>
        /// Avoid implementation without basics funcionalities
        /// </summary>
        internal interface ISoftwareArchitect
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
        /// A real implementation of a software architect
        /// </summary>
        internal class SoftwareArchitect : ISoftwareArchitect
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
            public SoftwareArchitect(string assembyName)
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
                if (@params != null && @params.Length > 2)
                    throw new ManyArgsException(this.GetDefaultErrorMessage() + " or ProgrammerEvolution.SoftwareArchitectLevelOne.exe \"Hello\" \"World\"");

                if (!this.GetValue(@params).Equals("hello world", StringComparison.OrdinalIgnoreCase))
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

        namespace UnitTests
        {
            [TestClass]
            public class SoftwareArchitect_UnitTests
            {
                private readonly SoftwareArchitect _softwareArchitect;
                private readonly string expectedResult;

                public SoftwareArchitect_UnitTests()
                {
                    _softwareArchitect = new SoftwareArchitect("UnitTestsAssembly.exe");
                    this.expectedResult = "Hello World";
                }

                [TestMethod]
                public void GetValue_OneString_ReturnsSameString()
                {
                    var message = "Hello World";
                    var result = _softwareArchitect.GetValue(message);

                    Assert.AreEqual(result, this.expectedResult);
                }

                [TestMethod]
                public void GetValue_TwoString_ReturnsJoinedString()
                {
                    var message = new string[] { "Hello", "World" };
                    var result = _softwareArchitect.GetValue(message);

                    Assert.AreEqual(result, this.expectedResult);
                }

                [TestMethod]
                [ExpectedException(typeof(ManyArgsException))]
                public void Validate_ManyArgs_RaisesManyArgsException()
                {
                    var message = new string[] { "Hello", "World", "throw ManyArgsException" };
                    _softwareArchitect.Validate(message);
                }

                [TestMethod]
                [ExpectedException(typeof(ValidateException))]
                public void Validate_ManyArgs_RaisesValidateException()
                {
                    var message = new string[] { "Hello World", "throw ValidateException" };
                    _softwareArchitect.Validate(message);
                }
            }
        }
    }
}

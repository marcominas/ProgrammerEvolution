# A funny evolution of a full trip to technology world.

I heard a history about the journey of someone that goes to IT world and decided to do my Hello World implementation evoution using C# as my language to this.

We will walk through some distinct phases:

## Apprentice 

When we see with a completely superficial basis.

```csharp
namespace ProgrammerEvolution
{
    class Apprentice
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
        }
    }
}
```

## Junior programmer 

Now we used to be think that don't know anything about but it seems cool.

```csharp
using System;

namespace ProgrammerEvolution
{
    class Junior
    {
        static void Main(string[] args)
        {
            // Now i know that "using" pattern is better and use of args :)
            Console.WriteLine(args[0]);
        }
    }
}
```

## Seasoned programmer 

The inocence has gone and now is the starting time to know that we know what are doing.

```csharp
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
```

## Senior programmer

Do you know what senior means? Exactly - I know what Im doing. See docstring documentation, segregation of 
functionalities with functions with one responsability only,

```csharp
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
```

## Software Engineer level one

See that the uppercase E on Engineer - now isolation were set to another level: there is a class, events, error 
management, use of interface to a well defined solution. I'm proud, I'm the guy, that's it.

```csharp
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
```

## Software Engineer level two

It's almost perfect - perfect is the key. Use of namespace let you see how organization and decouple is important.

```csharp
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
```

## Software Engineer level three

It's almost perfect - almost is the key and maybe almost word could be avoided. I took that state of art 
and - a better  and simpler function names is awsome, use of specifics exceptions classes. See exception refactor 
and use of a enum? Great, I love it! And how about that ternary if that defines enum values if one or two 
parameters is passsed. And talking about parameter - did you see that "args" were changed to "@params", wow.

```csharp
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
```

## Software Architect higher level

Well, take that state of art done by a engineer and put unit tests, integration test, lint, CI, CD and a great 
job is done. Better than it is impossible. Limit to a better solution is unreacheble.

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ProgrammerEvolution
{
    /// <summary>
    /// Extension methods to enhance this solution.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Filter a array of string to only items that are not empty.
        /// </summary>
        /// <param name="params">Array of string with sent params.</param>
        /// <returns></returns>
        public static string[] IgnoreEmptyString(this string[] @params)
        {
            return @params.Where<string>(s => !string.IsNullOrWhiteSpace(s)).ToArray();
        }
    }

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
                string message = string.Join(" ", @params.IgnoreEmptyString());
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
```

## An evolved programmer

After beeing in each step of this evolution I found the Nirvana of my programming life. And that simple but 
beautifull solution is better than anyone that you could find in any googled that you take.
Better than this only if you put cSharp aside and use Python.

```csharp
using System;

namespace ProgrammerEvolution
{
    class AnEvolvedProgrammer
    {
        static void Main(string[] args)
        {
            // after becoming a programmer, engineer and a 
            // architect, you will back to simplicity :)
            Console.WriteLine("Hello World!");
        }
    }
}
```

### Nirvana

Note that hasbag *#!/usr/bin/env * is unnecessary and were put just for best practices.

```python
#!/usr/bin/env python
print('Hello world ;)')
```

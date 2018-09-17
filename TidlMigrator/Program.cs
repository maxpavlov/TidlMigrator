using System;
using System.Collections.Generic;
using CommandLine;
using TidlMigrator.App;

namespace TidlMigrator
{
    internal class Program
    {
        public class Options
        {
            [Option("username1",
                Required = true,
                HelpText = "Specify the username for the first account, the source one.")]
            public string Username1 { get; set; }

            [Option("username2",
                Required = true,
                HelpText = "Specify the username for the second account, the target one.")]
            public string Username2 { get; set; }

            [Option("password1",
                Required = true,
                HelpText = "Specify the password for the first account.")]
            public string Password1 { get; set; }

            [Option("password2",
                Required = true,
                HelpText = "Specify the password for the second account.")]
            public string Password2 { get; set; }

        }

        static void Main(string[] args)
        {
            var parser = new Parser(settings =>
            {
                settings.HelpWriter = Console.Out;
            });

            parser.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    MigratorFacade.MigrateEverything(o.Username1, o.Password1, o.Username2, o.Password2)
                        .Wait();
                }).WithNotParsed(OutputErrorsAndExit);
        }

        private static void OutputErrorsAndExit(IEnumerable<Error> errors)
        {
            Console.WriteLine("Error parsing arguments. Details below:");
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
            Environment.Exit(1);
        }
    }
}

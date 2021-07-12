using System;
using StudentsToUniversity.CommandHandlers.Commands;
using StudentsToUniversity.CommandHandlers;
using StudentsToUniversity.ConfigJson;
using Microsoft.Extensions.Configuration;

namespace StudentsToUniversity
{
    public static class Program
    {
        private const string DeveloperName = "Dmitry Mefedov";
        private const string HintMessage = "Enter your command, or enter 'help' to get help.";
        private static IFileCabinetService fileCabinetService = new FileCabinetService();

        /// <summary>
        /// Program activity.
        /// </summary>
        /// <value name="isRunning">Initial value is true.</value>
        private static bool isRunning = true;

        /// <summary>
        /// Main method of our program.
        /// </summary>
        /// <param name="args">String.</param>
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            JsonValid();
            Console.WriteLine($"File Cabinet Application, developed by {Program.DeveloperName}");
            Console.WriteLine(Program.HintMessage);
            Console.WriteLine();

            do
            {
                Console.Write("> ");
                var inputs = Console.ReadLine().Split(' ', 2);
                const int commandIndex = 0;
                var command = inputs[commandIndex];

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine(Program.HintMessage);
                    continue;
                }

                const int parametersIndex = 1;
                var parameters = inputs.Length > 1 ? inputs[parametersIndex] : string.Empty;
                var commandHandler = CreateCommandHandlers();
                commandHandler.Handle(
                        new AppCommandRequest
                        {
                            Command = command,
                            Parameters = parameters,
                        });
            }
            while (isRunning);
        }

        private static void JsonValid()
        {
            IConfiguration config = new ConfigurationBuilder()
                     .SetBasePath("C:/Users/Терминатор/source/repos/StudentsToUniversity/StudentsToUniversity/Properties")
                     .AddJsonFile("universitys-rules.json", true, true)
                     .Build();

            UniversityJson bsu = (UniversityJson)ConfigurationBinder.Get(config, typeof(UniversityJson));

            int bsuRadophysMin = bsu.BSU.RadioPhys.Place;
        }

        private static ICommandHandler CreateCommandHandlers()
        {
            var exitCommandHandler = new ExitCommandHandler(ProgramActivity);
            var insertCommandHandler = new InsertCommandHandler(fileCabinetService);
            var listCommandHandler = new ListCommandHandler(fileCabinetService);
            var importCommandHandler = new ImportCommandHandler(fileCabinetService);
            var exportCommandHandler = new ExportCommandHandler(fileCabinetService);
            var distributeCommandHandler = new DistributeCommandHandler(fileCabinetService);
            var helpCommandHandler = new HelpCommandHandler();
            var printMissedCommand = new PrintMissedCommandInfoCommandHandler();

            exitCommandHandler.SetNext(helpCommandHandler);
            helpCommandHandler.SetNext(insertCommandHandler);
            insertCommandHandler.SetNext(listCommandHandler);
            listCommandHandler.SetNext(importCommandHandler);
            importCommandHandler.SetNext(distributeCommandHandler);
            distributeCommandHandler.SetNext(exportCommandHandler);
            exportCommandHandler.SetNext(printMissedCommand);

            return exitCommandHandler;
        }

        private static void ProgramActivity(bool activity)
        {
            isRunning = activity;
        }
    }
}

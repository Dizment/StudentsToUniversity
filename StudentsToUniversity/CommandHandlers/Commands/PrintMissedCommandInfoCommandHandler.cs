using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.CommandHandlers.Commands
{
    /// <summary>
    /// Handler printed missing command.
    /// </summary>
    public class PrintMissedCommandInfoCommandHandler : CommandHandlerBase
    {
        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>AppCommandRequest instance.</returns>
        public override AppCommandRequest Handle(AppCommandRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException($"The {nameof(request)} is null.");
            }

            PrintMissedCommandInfo(request.Parameters);
            return base.Handle(request);
        }

        private static void PrintMissedCommandInfo(string command)
        {
            Console.WriteLine($"There is no '{command}' command.");
            Console.WriteLine();
        }
    }
}

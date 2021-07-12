using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.CommandHandlers.Commands
{
    /// <summary>
    /// Handler for edit Record.
    /// </summary>
    public class ExitCommandHandler : CommandHandlerBase
    {
        private readonly Action<bool> isRunning;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExitCommandHandler"/> class.
        /// </summary>
        /// <param name="isRunning">delegaete Action in bool.</param>
        public ExitCommandHandler(Action<bool> isRunning)
        {
            this.isRunning = isRunning;
        }

        /// <summary>
        /// Special handles.
        /// </summary>
        /// <param name="request">Input record.</param>
        /// <returns>AppCommandRequest instance.</returns>
        public override AppCommandRequest Handle(AppCommandRequest request)
        {
            if (request == null)
            {
                throw new ArgumentException($"The {nameof(request)} is null");
            }

            if (string.Equals(request.Command, "exit", StringComparison.CurrentCultureIgnoreCase))
            {
                this.Exit(request.Parameters);
                return null;
            }
            else
            {
                return base.Handle(request);
            }
        }

        private void Exit(string parameters)
        {
            Console.WriteLine("Exiting an application...");
            this.isRunning(false);
        }
    }
}

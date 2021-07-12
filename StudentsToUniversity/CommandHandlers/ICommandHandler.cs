using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.CommandHandlers
{
    /// <summary>
    /// Command request.
    /// </summary>
    public interface ICommandHandler
    {
        /// <summary>
        /// Handles the special request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>AppCommandRequest Instance.</returns>
        AppCommandRequest Handle(AppCommandRequest request);

        /// <summary>
        /// Sets the next command.
        /// </summary>
        /// <param name="handler">The handler.</param>
        /// <returns>The next commandHandler.</returns>
        ICommandHandler SetNext(ICommandHandler handler);
    }
}

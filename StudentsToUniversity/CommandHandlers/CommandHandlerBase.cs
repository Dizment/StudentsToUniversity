using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.CommandHandlers
{
    public class CommandHandlerBase : ICommandHandler
    {
        private ICommandHandler nextHandler;

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>object AppCommandRequest.</returns>
        public virtual AppCommandRequest Handle(AppCommandRequest request)
        {
            if (this.nextHandler != null)
            {
                return this.nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Sets the next object commandHandler.
        /// </summary>
        /// <param name="handler">The handler.</param>
        /// <returns>The next commandHandler.</returns>
        public ICommandHandler SetNext(ICommandHandler handler)
        {
            this.nextHandler = handler;
            return handler;
        }
    }
}

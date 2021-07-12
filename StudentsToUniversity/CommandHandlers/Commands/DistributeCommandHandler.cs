using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StudentsToUniversity.CommandHandlers.Commands
{
    public class DistributeCommandHandler : CommandHandlerBase
    {
        private readonly IFileCabinetService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="InsertCommandHandler"/> class.
        /// </summary>
        /// <param name="service">Input service.</param>
        public DistributeCommandHandler(IFileCabinetService service)
        {
            this.service = service;
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

            if (string.Equals(request.Command, "distr", StringComparison.CurrentCultureIgnoreCase))
            {
                this.Distribute(request.Parameters);
                return null;
            }
            else
            {
                return base.Handle(request);
            }
        }

        private void Distribute(string parameters)
        {
            this.service.Distribute();
            Console.WriteLine("Please export the file.");
        }
    }
}

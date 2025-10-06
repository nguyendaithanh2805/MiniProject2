using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.Commands;
using Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Dispatchers
{
    public class CommanDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommanDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        async Task ICommandDispatcher.SendAsync<TCommand>(TCommand command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            await handler.HandleAsync(command);
        }
    }
}

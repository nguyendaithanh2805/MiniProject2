﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Commands
{
    public interface ICommandDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
    }
}

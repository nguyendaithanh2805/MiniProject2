using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.Commands;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Commands.Menus.Handlers
{
    public class RemoveMenuCommandHandler : ICommandHandler<RemoveMenuCommand>
    {
        private readonly IRepository<Menu> _repository;

        public RemoveMenuCommandHandler(IRepository<Menu> repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(RemoveMenuCommand command)
        {
            var menu = await _repository.GetByIdAsync(command.Id);
            if (menu is null)
                throw new NotFoundException($"Menu not found with Id {command.Id}");

            await _repository.DeleteAsync(menu);
        }
    }
}

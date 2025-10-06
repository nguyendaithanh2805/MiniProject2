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
    public class UpdateMenuCommandHandler : ICommandHandler<UpdateMenuCommand>
    {
        private readonly IRepository<Menu> _repository;

        public UpdateMenuCommandHandler(IRepository<Menu> repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(UpdateMenuCommand command)
        {
            var menu = await _repository.GetByIdAsync(command.Id);
            if (menu is null)
                throw new NotFoundException($"Menu not found with Id {command.Id}");

            menu.Name = command.Name;
            menu.Description = command.Description;
            await _repository.UpdateAsync(menu);
        }
    }
}

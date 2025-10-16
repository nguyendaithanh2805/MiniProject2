using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using Abstractions.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Handlers
{
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand>
    {
        private readonly IRepository<Menu> _repository;

        public UpdateMenuCommandHandler(IRepository<Menu> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await _repository.GetByIdAsync(request.Id);
            if (menu is null)
                throw new NotFoundException($"Menu not found with Id {request.Id}");

            menu.Name = request.Name;
            menu.Description = request.Description;
            await _repository.UpdateAsync(menu, cancellationToken);
        }
    }
}

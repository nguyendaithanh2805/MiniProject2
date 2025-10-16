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
    public class RemoveMenuCommandHandler : IRequestHandler<RemoveMenuCommand>
    {
        private readonly IRepository<Menu> _repository;

        public RemoveMenuCommandHandler(IRepository<Menu> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await _repository.GetByIdAsync(request.Id);
            if (menu is null)
                throw new NotFoundException($"Menu not found with Id {request.Id}");

            await _repository.DeleteAsync(menu, cancellationToken);
        }
    }
}

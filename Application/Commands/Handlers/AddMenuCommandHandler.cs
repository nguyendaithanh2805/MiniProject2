using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Interfaces;
using Domain.Entities;
using Mapster;
using MapsterMapper;
using MediatR;

namespace Application.Commands.Handlers
{
    public class AddMenuCommandHandler : IRequestHandler<AddMenuCommand>
    {
        private readonly IRepository<Menu> _menuRepository;
        public AddMenuCommandHandler(IRepository<Menu> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task Handle(AddMenuCommand request, CancellationToken cancellationToken)
        {
            await _menuRepository.AddAsync(request.Adapt<Menu>(), cancellationToken);
        }
    }
}

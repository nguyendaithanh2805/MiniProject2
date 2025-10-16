using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Exceptions;
using Abstractions.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections;
using Mapster;

namespace Application.Queries.Handlers
{
    public class GetMenuByIdHandler : IRequestHandler<GetMenuByIdQuery, MenuDto>
    {
        private readonly IRepository<Menu> _menuRepository;

        public GetMenuByIdHandler(IRepository<Menu> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<MenuDto> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            var menu = await _menuRepository.GetByIdAsync(request.Id, cancellationToken);
            if (menu is null)
                throw new NotFoundException($"Menu not found with Id {request.Id}");

            return menu.Adapt<MenuDto>();
        }
    }
}

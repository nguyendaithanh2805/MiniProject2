using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Abstractions.Interfaces;
using Domain.Entities;
using MediatR;
using Mapster;

namespace Application.Queries.Handlers
{
    public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusQuery, IEnumerable<MenuDto>>
    {
        private readonly IRepository<Menu> _menuRepository;

        public GetAllMenusQueryHandler(IRepository<Menu> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<MenuDto>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
        {
            var menus = await _menuRepository.GetAllAsync(cancellationToken);
            return menus.Adapt<IEnumerable<MenuDto>>();
        }
    }
}

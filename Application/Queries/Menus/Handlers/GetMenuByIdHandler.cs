using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Queries;
using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Queries.Menus.Handlers
{
    public class GetMenuByIdHandler : IQueryHandler<GetMenuByIdQuery, MenuDto>
    {
        private readonly IRepository<Menu> _menuRepository;

        private readonly IMapper _mapper;

        public GetMenuByIdHandler(IRepository<Menu> menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<MenuDto> HandleAsync(GetMenuByIdQuery query)
        {
            var menu = await _menuRepository.GetByIdAsync(query.Id);
            if (menu is null)
                throw new NotFoundException($"Menu not found with Id {query.Id}");

            return _mapper.Map<MenuDto>(menu);
        }
    }
}

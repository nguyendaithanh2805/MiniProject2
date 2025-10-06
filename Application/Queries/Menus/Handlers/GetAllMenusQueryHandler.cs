using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Queries;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Queries.Menus.Handlers
{
    public class GetAllMenusQueryHandler : IQueryHandler<GetAllMenusQuery, IEnumerable<MenuDto>>
    {
        private readonly IRepository<Menu> _menuRepository;
        private readonly IMapper _mapper;

        public GetAllMenusQueryHandler(IRepository<Menu> menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuDto>> HandleAsync(GetAllMenusQuery query)
        {
            return _mapper.Map<IEnumerable<MenuDto>>(await _menuRepository.GetAllAsync());
        }
    }
}

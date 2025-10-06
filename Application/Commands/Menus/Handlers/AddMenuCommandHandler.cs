using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Commands.Menus.Handlers
{
    public class AddMenuCommandHandler : ICommandHandler<AddMenuCommand>
    {
        private readonly IRepository<Menu> _menuRepository;
        private readonly IMapper _mapper;

        public AddMenuCommandHandler(IRepository<Menu> menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task HandleAsync(AddMenuCommand command)
        {
            await _menuRepository.AddAsync(_mapper.Map<Menu>(command));
        }
    }
}

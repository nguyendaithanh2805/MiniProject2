using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.Commands;
using Application.Interfaces;
using AutoMapper;

namespace Application.Commands.News.Handlers
{
    public class AddNewCommandHandler : ICommandHandler<AddNewCommand>
    {
        private readonly IRepository<Domain.Entities.News> _repository;
        private readonly IMapper _mapper;

        public AddNewCommandHandler(IRepository<Domain.Entities.News> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task HandleAsync(AddNewCommand command)
        {
            await _repository.AddAsync(_mapper.Map<Domain.Entities.News>(command));
        }
    }
}

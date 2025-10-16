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
    public class AddNewCommandHandler : IRequestHandler<AddNewCommand>
    {
        private readonly IRepository<News> _repository;

        public AddNewCommandHandler(IRepository<News> repository)
        {
            _repository = repository;
        }

        public async Task Handle(AddNewCommand request, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(request.Adapt<News>(), cancellationToken);
        }
    }
}

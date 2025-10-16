using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using Abstractions.Interfaces;
using MediatR;
using Domain.Entities;

namespace Application.Commands.Handlers
{
    public class RemoveNewCommandHandler : IRequestHandler<RemoveNewCommand>
    {
        private readonly IRepository<News> _repository;

        public RemoveNewCommandHandler(IRepository<News> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveNewCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity is null)
                throw new NotFoundException($"New not found with Id {request.Id}");

            await _repository.DeleteAsync(entity, cancellationToken);
        }
    }
}

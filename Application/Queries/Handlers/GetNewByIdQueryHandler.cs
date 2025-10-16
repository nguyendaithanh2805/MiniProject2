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
using MapsterMapper;
using Mapster;

namespace Application.Queries.Handlers
{
    public class GetNewByIdQueryHandler : IRequestHandler<GetNewByIdQuery, NewsDto>
    {
        private readonly IRepository<News> _repository;

        public GetNewByIdQueryHandler(IRepository<News> repository)
        {
            _repository = repository;
        }

        public async Task<NewsDto> Handle(GetNewByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity is null)
                throw new NotFoundException($"New not found with Id {request.Id}");

            return entity.Adapt<NewsDto>();
        }
    }
}

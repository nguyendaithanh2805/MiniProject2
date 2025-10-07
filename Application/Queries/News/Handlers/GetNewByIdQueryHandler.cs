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

namespace Application.Queries.News.Handlers
{
    public class GetNewByIdQueryHandler : IQueryHandler<GetNewByIdQuery, NewsDto>
    {
        private readonly IRepository<Domain.Entities.News> _repository;
        private readonly IMapper _mapper;

        public GetNewByIdQueryHandler(IRepository<Domain.Entities.News> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<NewsDto> HandleAsync(GetNewByIdQuery query)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity is null)
                throw new NotFoundException($"New not found with Id {query.Id}");

            return _mapper.Map<NewsDto>(entity);
        }
    }
}

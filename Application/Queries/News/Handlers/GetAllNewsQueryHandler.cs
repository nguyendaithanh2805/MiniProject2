using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Queries;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;

namespace Application.Queries.News.Handlers
{
    public class GetAllNewsQueryHandler : IQueryHandler<GetAllNewsQuery, IEnumerable<NewsDto>>
    {
        private readonly IRepository<Domain.Entities.News> _repository;
        private readonly IMapper _mapper;

        public GetAllNewsQueryHandler(IRepository<Domain.Entities.News> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NewsDto>> HandleAsync(GetAllNewsQuery query)
        {
            return _mapper.Map<IEnumerable<NewsDto>>(await _repository.GetAllAsync());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Abstractions.Interfaces;
using MediatR;
using Domain.Entities;
using MapsterMapper;
using Mapster;

namespace Application.Queries.Handlers
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQuery, IEnumerable<NewsDto>>
    {
        private readonly IRepository<News> _repository;

        public GetAllNewsQueryHandler(IRepository<News> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NewsDto>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            var news = await _repository.GetAllAsync(cancellationToken);
            return news.Adapt<IEnumerable<NewsDto>>();
        }
    }
}

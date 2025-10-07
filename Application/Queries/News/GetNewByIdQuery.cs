using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Queries;
using Application.DTOs;

namespace Application.Queries.News
{
    public class GetNewByIdQuery : IQuery<NewsDto>
    {
        public int Id { get; set; }

        public GetNewByIdQuery(int id)
        {
            Id = id;
        }
    }
}

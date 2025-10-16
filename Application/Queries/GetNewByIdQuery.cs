using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using MediatR;

namespace Application.Queries
{
    public class GetNewByIdQuery : IRequest<NewsDto>
    {
        public int Id { get; set; }

        public GetNewByIdQuery(int id)
        {
            Id = id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Queries;
using Application.DTOs;

namespace Application.Queries.News
{
    public class GetAllNewsQuery : IQuery<IEnumerable<NewsDto>>
    {
    }
}

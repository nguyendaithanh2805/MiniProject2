using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Queries;
using Application.DTOs;

namespace Application.Queries.Menus
{
    public class GetMenuByIdQuery : IQuery<MenuDto>
    {
        public int Id { get; set; }

        public GetMenuByIdQuery(int id)
        {
            Id = id;
        }
    }
}

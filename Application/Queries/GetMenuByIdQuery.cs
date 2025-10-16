﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using MediatR;

namespace Application.Queries
{
    public class GetMenuByIdQuery : IRequest<MenuDto>
    {
        public int Id { get; set; }

        public GetMenuByIdQuery(int id)
        {
            Id = id;
        }
    }
}

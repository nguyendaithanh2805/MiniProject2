using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.Menus;
using Application.Commands.News;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddMenuCommand, Menu>();
            CreateMap<AddNewCommand, News>();

            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<News, NewsDto>().ReverseMap();
        }
    }
}

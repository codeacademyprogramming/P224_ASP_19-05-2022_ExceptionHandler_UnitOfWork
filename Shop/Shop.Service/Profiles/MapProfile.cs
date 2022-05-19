﻿using AutoMapper;
using Shop.Core.Entities;
using Shop.Service.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Service.Profiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryPutDto, Category>();
            CreateMap<Category, CategoryListDto>();
            CreateMap<Category, CategoryGetDto>();

        }
    }
}

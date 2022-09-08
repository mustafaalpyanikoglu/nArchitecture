﻿using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles:Profile
    {
        //mapleme profilleri yazılır
        public MappingProfiles()
        {
            CreateMap<Brand, CreatedBrandDto>().ReverseMap(); //Brand->CreatedBrandDto ya çevir bu ikisi karşılaşırsa
                                                              //ReverseMap() tam tersinin de olabilmesini sağlar
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        }
    }
}

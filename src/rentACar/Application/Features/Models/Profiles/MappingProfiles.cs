using System;
using Application.Features.Models.Commands.CreateModel;
using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, ModelListDto>().ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name)).ReverseMap();
            CreateMap<ModelListModel, IPaginate<Model>>().ReverseMap();
            CreateMap<Model, CreateModelCommand>().ReverseMap();
            CreateMap<Model, CreatedModelDto>().ReverseMap();
        }
    }
}


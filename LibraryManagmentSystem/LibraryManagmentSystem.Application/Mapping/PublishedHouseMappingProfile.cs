using AutoMapper;
using LibraryManagmentSystem.Application.DTO;
using LibraryManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.Mapping
{
    public class PublishedHouseMappingProfile : Profile
    {
        public PublishedHouseMappingProfile()
        {
            CreateMap<CreatePublishedHouseDto, PublishedHouse>()
                .ForMember(x => x.PublishedHouseName, opt => opt.MapFrom(src => src.PublishedHouseName))
                .ReverseMap();
        }
    }
}

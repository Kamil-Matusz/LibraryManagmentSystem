using AutoMapper;
using LibraryManagmentSystem.Application.Commands;
using LibraryManagmentSystem.Application.DTO;
using LibraryManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.Mapping
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<CreateReservationDto, Reservation>()
                  .ForMember(x => x.BookId, opt => opt.MapFrom(src => src.BookId))
                  .ForMember(x => x.ReservationStart, opt => opt.MapFrom(src => src.ReservationStart))
                  .ForMember(x => x.ReservationEnd, opt => opt.MapFrom(src => src.ReservationEnd))
                  .ForMember(x => x.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<Reservation, CreateReservationDto>()
                  .ForMember(x => x.BookId, opt => opt.MapFrom(src => src.BookId))
                  .ForMember(x => x.ReservationStart, opt => opt.MapFrom(src => src.ReservationStart))
                  .ForMember(x => x.ReservationEnd, opt => opt.MapFrom(src => src.ReservationEnd))
                  .ForMember(x => x.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<ReservationDto, Reservation>();

            CreateMap<Reservation, ReservationDto>();

            CreateMap<ReservationDto, EditReservationCommand>();

            CreateMap<ReservationDto, RentalExtendCommand>();
        }
    }
}

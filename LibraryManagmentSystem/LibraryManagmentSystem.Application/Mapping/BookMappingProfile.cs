using AutoMapper;
using LibraryManagmentSystem.Application.Commands;
using LibraryManagmentSystem.Application.DTO;
using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Application.Mapping;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<BookDto, Book>()
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(x => x.Author, opt => opt.MapFrom(src => src.Author))
            .ForMember(x => x.Genre, opt => opt.MapFrom(src => src.Genre))
            .ForMember(x => x.PublishedHouseId, opt => opt.MapFrom(src => src.PublishedHouseId))
            .ForMember(x => x.PublishedDate, opt => opt.MapFrom(src => src.PublishedDate));

        CreateMap<Book, BookDto>()
            .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dto => dto.Author, opt => opt.MapFrom(src => src.Author))
            .ForMember(dto => dto.Genre, opt => opt.MapFrom(src => src.Genre))
            .ForMember(dto => dto.PublishedHouseId, opt => opt.MapFrom(src => src.PublishedHouseId))
            .ForMember(dto => dto.PublishedDate , opt => opt.MapFrom(src => src.PublishedDate));

        CreateMap<CreateBookDto, Book>()
            .ForMember(x => x.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(x => x.Author, opt => opt.MapFrom(src => src.Author))
            .ForMember(x => x.Genre, opt => opt.MapFrom(src => src.Genre))
            .ForMember(x => x.PublishedHouseId, opt=> opt.MapFrom(src =>src.PublishedHouseId))
            .ForMember(x => x.PublishedDate, opt => opt.MapFrom(src => src.PublishedDate));

        CreateMap<Book, CreateBookDto>()
            .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dto => dto.Author, opt => opt.MapFrom(src => src.Author))
            .ForMember(dto => dto.Genre, opt => opt.MapFrom(src => src.Genre))
            .ForMember(x => x.PublishedHouseId, opt => opt.MapFrom(src => src.PublishedHouseId))
            .ForMember(dto => dto.PublishedDate, opt => opt.MapFrom(src => src.PublishedDate));

        CreateMap<BookDto, EditBookCommand>();

        CreateMap<BookDto, DeleteBookCommand>();

        CreateMap<Book,BookByTypeDto>();

        CreateMap<BookByTypeDto,Book>();
    }
}
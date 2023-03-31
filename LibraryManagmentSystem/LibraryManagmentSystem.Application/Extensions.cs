using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryManagmentSystem.Application.Commands;
using LibraryManagmentSystem.Application.DTO;
using LibraryManagmentSystem.Application.Mapping;
using LibraryManagmentSystem.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagmentSystem.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateBookCommand));
        services.AddAutoMapper(typeof(BookMappingProfile));

        services
            .AddValidatorsFromAssemblyContaining<BookDto>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();

        return services;
    }
}
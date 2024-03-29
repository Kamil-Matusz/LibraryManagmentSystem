﻿using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryManagmentSystem.Application.ApplicationUser;
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
        services.AddMediatR(typeof(CreatePublishedHouseCommand));
        services.AddMediatR(typeof(EditBookCommand));
        services.AddMediatR(typeof(DeleteBookCommand));
        services.AddMediatR(typeof(RentalExtendCommand));
        services.AddAutoMapper(typeof(BookMappingProfile));
        services.AddAutoMapper(typeof(PublishedHouseMappingProfile));

        services.AddScoped<IUserContext, UserContext>();

        services
            .AddValidatorsFromAssemblyContaining<BookDto>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();

        return services;
    }
}
using Xunit;
using LibraryManagmentSystem.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagmentSystem.Application.DTO;
using LibraryManagmentSystem.Domain.Entities;
using FluentAssertions;

namespace LibraryManagmentSystem.Application.Mapping.Tests
{
    public class ReservationMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ShouldMapReservationDtoToReservation()
        {
            // arrange
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<ReservationMappingProfile>());
            var mapper = configuration.CreateMapper();
            var dto = new ReservationDto
            {
                BookId = 1,
                ReservationStart = DateTime.Now,
                ReservationEnd = DateTime.Now.AddDays(1),
                StatusId = 1,
                UserId = "2"
            };

            // act
            var result = mapper.Map<Reservation>(dto);

            // assert
            result.Should().NotBeNull();
            result.BookId.Should().Be(dto.BookId);
            result.ReservationStart.Should().Be(dto.ReservationStart);
            result.ReservationEnd.Should().Be(dto.ReservationEnd);
            result.StatusId.Should().Be(dto.StatusId);
            result.UserId.Should().Be(dto.UserId);
        }

        [Fact()]
        public void MappingProfile_ShouldMapReservationToReservationDto()
        {
            // arrange
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<ReservationMappingProfile>());
            var mapper = configuration.CreateMapper();
            var reservation = new Reservation
            {
                BookId = 1,
                ReservationStart = DateTime.Now,
                ReservationEnd = DateTime.Now.AddDays(1),
                StatusId = 1,
                UserId = "2"
            };

            // act
            var result = mapper.Map<ReservationDto>(reservation);

            // assert
            result.Should().NotBeNull();
            result.BookId.Should().Be(reservation.BookId);
            result.ReservationStart.Should().Be(reservation.ReservationStart);
            result.ReservationEnd.Should().Be(reservation.ReservationEnd);
            result.StatusId.Should().Be(reservation.StatusId);
            result.UserId.Should().Be(reservation.UserId);
        }
    }
}
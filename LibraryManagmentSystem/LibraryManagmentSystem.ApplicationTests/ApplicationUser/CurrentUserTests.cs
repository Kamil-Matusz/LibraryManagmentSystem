using Xunit;
using LibraryManagmentSystem.Application.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace LibraryManagmentSystem.Application.ApplicationUser.Tests
{
    public class CurrentUserTests
    {
        [Fact()]
        public void IsInRole_ShouldReturnTrue()
        {
            // arrange
            var currentUser = new CurrentUser("1","admin@test.com",new List<string> {"Admin","User"});

            // act
            var isInRole = currentUser.IsInRole("Admin");

            // assert

            isInRole.Should().BeTrue();
        }
    }
}
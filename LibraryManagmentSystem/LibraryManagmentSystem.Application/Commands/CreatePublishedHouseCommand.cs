using LibraryManagmentSystem.Application.DTO;
using MediatR;

namespace LibraryManagmentSystem.Application.Commands
{
    public class CreatePublishedHouseCommand : CreatePublishedHouseDto,IRequest
    {
    }
}

using Application.Common;
using Application.DTOs;
using MediatR;

namespace Application.Features.CategoryFetures.Querys.GetAllUsers
{
    public record GetAllUsersQuery() : IRequest<OperationResult<List<UserDto>>>;

    
}
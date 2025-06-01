using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Features.CategoryFetures.Querys.GetAllUsers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, OperationResult<List<UserDto>>>
{
    private readonly IUserRepository _userRepo;

    public GetAllUsersHandler(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<OperationResult<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepo.GetAllAsync();

        var userDtos = users.Select(user => new UserDto
        {
            UserId = user.UserId,
            Email = user.Email,
            UserName = user.UserName
        }).ToList();

        return OperationResult<List<UserDto>>.Success(userDtos);
    }
}

using Application.Common;
using Application.DTOs;
using MediatR;

namespace Application.Features.Auth.Commands
{
    public record LoginUserCommand(LoginUserDto Dto) : IRequest<OperationResult<LoginUserResponseDto>>;
}
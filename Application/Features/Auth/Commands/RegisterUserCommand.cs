using Application.Common;
using Application.DTOs;
using MediatR;

namespace Application.Features.Auth.Commands
{
    public record RegisterUserCommand(RegisterUserDto Dto) : IRequest<OperationResult<string>>;
}
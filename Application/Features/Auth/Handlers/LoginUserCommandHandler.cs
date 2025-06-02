using Application.Common;
using Application.DTOs;
using Application.Features.Auth.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, OperationResult<LoginUserResponseDto>>
    {
        private readonly IUserRepository _userRepo;
        private readonly IPasswordService _passwordService;
        private readonly IJwtTokenService _jwtTokenService;


        private string InvalidCredentialsMessage => "Ogiltiga inloggningsuppgifter.";

        public LoginUserCommandHandler(IUserRepository userRepo, IPasswordService passwordService,
            IJwtTokenService jwtTokenService)
        {
            _userRepo = userRepo;
            _passwordService = passwordService;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<OperationResult<LoginUserResponseDto>> Handle(LoginUserCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            User? user = await _userRepo.GetByEmailAsync(dto.Email); 
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                return OperationResult<LoginUserResponseDto>.Failure(InvalidCredentialsMessage);
            }

            var token = _jwtTokenService.GenerateToken(user);


            // Here you would typically generate a JWT token or similar
            // For simplicity, we return a success message
            return OperationResult<LoginUserResponseDto>.Success(new LoginUserResponseDto
            {
                Token = token,
                UserName = user.UserName,
                Email = user.Email
            });

        }
    }
}
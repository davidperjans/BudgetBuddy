using Application.Common;
using Application.DTOs;
using Application.Features.Auth.Commands;
using Application.Interfaces;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Features.Auth.Handlers
{
    public class RegisterUserCommandHandler :IRequestHandler<RegisterUserCommand, OperationResult<string>>
    {
        private readonly IUserRepository _userRepo;
        private readonly IPasswordService _passwordService;
        private readonly IValidator<RegisterUserDto> _validator;

        public RegisterUserCommandHandler(IUserRepository userRepo, IPasswordService passwordService, IValidator<RegisterUserDto> validator)
        {
            _validator = validator;
            _userRepo = userRepo;
            _passwordService = passwordService;

        }

        public async Task<OperationResult<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.Dto);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                return OperationResult<string>.Failure(errors);
            }
            
            var dto = request.Dto;

            if (await _userRepo.ExistsByEmailAsync(dto.Email))
                return OperationResult<string>.Failure("E-postadressen används redan.");

            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                PasswordHash = _passwordService.HashPassword(dto.Password)
            };

            await _userRepo.AddAsync(user);
            return OperationResult<string>.Success("Användare registrerad.");
        }
    }
}
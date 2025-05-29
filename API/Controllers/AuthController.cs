using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Auth.Commands;


namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator context)
        {
            _mediator = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            var result = await _mediator.Send(new LoginUserCommand(dto));

            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(result.Data);

        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            var result = await _mediator.Send(new RegisterUserCommand(dto));

            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

    }
}

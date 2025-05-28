using Application.DTOs;
using Application.Features.CategoryFetures.Commands.CreateACategory;
using Application.Features.CategoryFetures.Commands.DeleteCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
        {
            var result = await _mediator.Send(new CreateCategoryCommand(dto));

            if (result.IsSuccess) return Ok(result); 
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryDto dto)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(dto));

            if (result.IsSuccess) return Ok(result);
            return BadRequest(result);
        }
    }
}

using Application.DTOs;
using Application.Features.TransactionFeatures.Commands;
using Application.Features.TransactionFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionDto dto)
        {
            var result = await _mediator.Send(new CreateTransactionCommand(dto));

            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAll(Guid userId)
        {
            var result = await _mediator.Send(new GetAllTransactionsQuery(userId));

            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTransactionDto dto)
        {
            var result = await _mediator.Send(new UpdateTransactionCommand(dto));

            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTransactionDto dto)
        {
            var result = await _mediator.Send(new DeleteTransactionCommand(dto));

            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

    }
}

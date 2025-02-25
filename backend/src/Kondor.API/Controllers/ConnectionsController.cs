using Kondor.Application.Common.Models;
using Kondor.Application.Connections.Commands.CreateConnection;
using Kondor.Application.Connections.Queries.GetConnections;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kondor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConnectionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConnectionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ConnectionDto>>> GetAll()
    {
        return Ok(await _mediator.Send(new GetConnectionsQuery()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ConnectionDto>> GetById(Guid id)
    {
        // Esta parte la implementaremos después
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateConnectionCommand command)
    {
        var result = await _mediator.Send(command);
        
        if (!result.IsSuccess)
            return BadRequest(result.Error);
            
        return CreatedAtAction(nameof(GetById), new { id = result.Value }, result.Value);
    }
}
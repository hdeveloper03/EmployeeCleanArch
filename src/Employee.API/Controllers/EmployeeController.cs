using Employee.Application.Commands;
using Employee.Application.DTO;
using Employee.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetAllEmployee")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<List<EmployeeDTO>> GetAllEmployee()
        {
            return await _mediator.Send(new GetAllEmployeeListQuery());
        }

        [HttpPost(Name = "CreateEmployee")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var command = new DeleteEmployeeCommand() { EmployeeId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

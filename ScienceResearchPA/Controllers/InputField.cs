using App.Common.Models;
using App.InputFields.Commands;
using App.FieldTypes.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ScienceResearchPA.Controllers
{
    [Route("api/input-field")]
    [ApiController]
    public class InputFieldController : BaseApiController
    {
        [HttpPost("text")]
        public async Task<ActionResult<ServiceResult<object>>> PostTextInput(CreateUpdateInputTextFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut("text")]
        public async Task<ActionResult<ServiceResult<object>>> PutTextInput(CreateUpdateInputTextFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete("text/{id}")]
        public async Task<ActionResult<ServiceResult<object>>> DeleteTextInput(int id, CancellationToken cancellationToken, bool isCompleteRemoval = true)
        {
            return Ok(await Mediator.Send(null, cancellationToken));
        }

        [HttpPost("number")]
        public async Task<ActionResult<ServiceResult<object>>> PostNumberInput(CreateUpdateInputNumberFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut("number")]
        public async Task<ActionResult<ServiceResult<object>>> PutNumberInput(CreateUpdateInputNumberFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete("number/{id}")]
        public async Task<ActionResult<ServiceResult<object>>> DeleteNumberInput(int id, CancellationToken cancellationToken, bool isCompleteRemoval = true)
        {
            return Ok(await Mediator.Send(null, cancellationToken));
        }

        [HttpPost("number-phone")]
        public async Task<ActionResult<ServiceResult<object>>> PostNumberPhoneInput(CreateUpdateInputNumberPhoneFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut("number-phone")]
        public async Task<ActionResult<ServiceResult<object>>> PutNumberPhoneInput(CreateUpdateInputNumberPhoneFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete("number-phone/{id}")]
        public async Task<ActionResult<ServiceResult<object>>> DeleteNumberPhoneInput(int id, CancellationToken cancellationToken, bool isCompleteRemoval = true)
        {
            return Ok(await Mediator.Send(null, cancellationToken));
        }

        [HttpPost("date")]
        public async Task<ActionResult<ServiceResult<object>>> PostDateInput(CreateUpdateInputDateFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut("date")]
        public async Task<ActionResult<ServiceResult<object>>> PutDateInput(CreateUpdateInputDateFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete("date/{id}")]
        public async Task<ActionResult<ServiceResult<object>>> DeleteDateInput(int id, CancellationToken cancellationToken, bool isCompleteRemoval = true)
        {
            return Ok(await Mediator.Send(null, cancellationToken));
        }
    }
}

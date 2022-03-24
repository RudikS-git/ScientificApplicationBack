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
        [HttpPost("")]
        public async Task<ActionResult<ServiceResult<object>>> PostTextInput(CreateUpdateInputFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut("")]
        public async Task<ActionResult<ServiceResult<object>>> PutTextInput(CreateUpdateInputFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<object>>> DeleteTextInput(int id, CancellationToken cancellationToken, bool isCompleteRemoval = true)
        {
            return Ok(await Mediator.Send(null, cancellationToken));
        }
    }
}

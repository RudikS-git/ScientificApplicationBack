using App.Common.Models;
using App.InputFields.Commands;
using App.FieldTypes.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ScienceResearchPA.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/input-field")]
    [ApiController]
    public class InputFieldController : BaseApiController
    {
        [HttpPost("")]
        public async Task<ActionResult> PostTextInput(CreateUpdateInputFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut("")]
        public async Task<ActionResult> PutTextInput(CreateUpdateInputFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTextInput(int id, CancellationToken cancellationToken, bool isCompleteRemoval = true)
        {
            return Ok(await Mediator.Send(new DeleteInputFieldCommand(id), cancellationToken));
        }
    }
}

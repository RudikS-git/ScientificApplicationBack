using App.Common.Models;
using App.SelectFields.Commands;
using App.FieldTypes.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using App.SelectFields.Queries;

namespace ScienceResearchPA.Controllers
{
    [Route("api/select-field")]
    [ApiController]
    public class SelectField : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<ServiceResult<object>>> PostSelect(CreateUpdateSelectFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResult<object>>> PutSelect(CreateUpdateSelectFieldCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<object>>> DeleteSelect(int id, CancellationToken cancellationToken, bool isCompleteRemoval = true)
        {
            return Ok(await Mediator.Send(null, cancellationToken));
        }

        [HttpGet("options/{id}")]
        public async Task<ActionResult<ServiceResult<object>>> AsyncSelectOptions(int id, string search, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetSelectOptionsQuery(id, search), cancellationToken));
        }
    }
}

using App.Common.Models;
using App.FieldSets.Commands;
using App.FieldTypes.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ScienceResearchPA.Controllers
{
    [Route("api/field-set")]
    [ApiController]
    public class FieldSet : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<ServiceResult<object>>> Post(CreateAddEntityFieldCommandCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResult<object>>> Put(CreateAddEntityFieldCommandCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<object>>> Delete(int id, CreateAddEntityFieldCommandCommand command, CancellationToken cancellationToken, bool isCompleteRemoval = true)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}

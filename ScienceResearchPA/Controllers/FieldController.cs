using App.Common.Models;
using App.FieldTypes.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ScienceResearchPA.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : BaseApiController
    {
        [HttpGet("types")]
        public async Task<ActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetFieldTypesQuery(), cancellationToken));
        }
    }
}

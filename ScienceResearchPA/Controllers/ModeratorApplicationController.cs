using App.Applications.DTOs;
using App.Applications.Queries;
using App.ApplicationSubmissions.Commands;
using App.ApplicationSubmissions.Queries;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ScienceResearchPA.Controllers
{
    [Authorize(Roles = "Moderator")]
    [Route("api/moderator/application")]
    public class ModeratorApplicationController : BaseApiController
    {
        [HttpGet("{page}/{pageSize}")]
        public async Task<ActionResult> Get([FromQuery] ApplicationQueryParamsDto filterParams, CancellationToken cancellationToken, int page = 1, int pageSize = 15)
        {
            return Ok(await Mediator.Send(new GetApplicationsQuery(page, pageSize, filterParams), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] GetApplicationByIdQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet("states")]
        public async Task<ActionResult> GetApplicationStates ([FromRoute] GetApplicationStatesQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}

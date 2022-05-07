using App.AdminApplications.DTOs;
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
    [Route("api/moderator/application-submission")]
    public class ModeratorApplicationSubmissionController : BaseApiController
    {
        [HttpGet("{applicationId}/{page}/{pageSize}")]
        public async Task<ActionResult> Get(int applicationId, int page, int pageSize, [FromQuery] ApplicationQueryParamsDto filterParams, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllApplicationSubmission(applicationId, page, pageSize, filterParams), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllApplicationSubmissionById(id), cancellationToken));
        }

        [HttpPatch("state/{id}/{stateId}")]
        public async Task<ActionResult> SetApplicationState(int id, ApplicationStatesEnum stateId, [FromForm]string comment, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new SetApplicationState(id, stateId, comment), cancellationToken));
        }
    }
}

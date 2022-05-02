using App.Applications.DTOs;
using App.Applications.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ScienceResearchPA.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "User")]
    [ApiController]
    public class ApplicationController : BaseApiController
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
    }
}

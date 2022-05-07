using App.HistorySubmissionApplications.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ScienceResearchPA.Controllers
{
    [Authorize(Roles = "User, Moderator")]
    [Route("api/history-submission")]
    [ApiController]
    public class HistorySubmissionController : BaseApiController
    {
        [HttpGet("{applicationSubmissionId}/{page}/{pageSize}")]
        public async Task<ActionResult> Get(int applicationSubmissionId, int page, int pageSize, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetHistorySubmissions(applicationSubmissionId, page, pageSize), cancellationToken));
        }
    }
}

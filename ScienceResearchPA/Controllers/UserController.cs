using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace ScienceResearchPA.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseApiController
    {
        [HttpPost("register")]
        public async Task<ActionResult> RegisterPost(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(null, cancellationToken));
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginPost(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(null, cancellationToken));
        }

        [HttpPost("restore")]
        public async Task<ActionResult> RestorePost(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(null, cancellationToken));
        }

        [HttpGet("me")]
        public async Task<ActionResult> MeGet(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(null, cancellationToken));
        }
    }
}

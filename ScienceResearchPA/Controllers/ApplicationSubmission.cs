using App.Applications.Commands;
using App.Common.Models;
using App.Common.Interfaces;
using App.Queries;
using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.Applications.DTOs;
using App.Applications.Queries;
using App.SelectFields.Commands;
using App.ApplicationSubmissions.Commands;
using Microsoft.AspNetCore.Authorization;
using App.ApplicationSubmissions.Queries;

namespace ScienceResearchPA.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/application-submission")]
    [ApiController]
    public class ApplicationSubmission : BaseApiController
    {
        [HttpGet("{page}/{pageSize}")]
        public async Task<ActionResult> Get(int page, int pageSize, [FromQuery] ApplicationQueryParamsDto filterParams, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetApplicationSubmissionsQuery(page, pageSize, filterParams), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetApplicationSubmissionByIdQuery(id), cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateUpdateApplicationSubmissionCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut]
        public async Task<ActionResult> Put(CreateUpdateApplicationSubmissionCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteApplicationSubmissionCommand() { Id = id }, cancellationToken));
        }
    }
}

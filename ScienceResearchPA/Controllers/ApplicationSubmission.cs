using App.AdminApplications.Commands;
using App.Common.Models;
using App.Common.Interfaces;
using App.AdminApplications.Queries;
using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using App.AdminApplications.DTOs;
using App.SelectFields.Commands;
using App.ApplicationSubmissions.Commands;
using Microsoft.AspNetCore.Authorization;
using App.ApplicationSubmissions.Queries;
using Domain.Enums;
using App.ApplicationSubmissions.DTOs.Request;

namespace ScienceResearchPA.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/application-submission")]
    [ApiController]
    public class ApplicationSubmission : BaseApiController
    {
        [HttpGet("{applicationId}/{page}/{pageSize}")]
        public async Task<ActionResult> Get(int applicationId, int page, int pageSize, [FromQuery] ApplicationSubmissionQueryParams filterParams, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetApplicationSubmissions(applicationId, page, pageSize, filterParams), cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetApplicationSubmissionById(id), cancellationToken));
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

        [HttpPatch("send/{id}")]
        public async Task<ActionResult> SendApplicationForVerification(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new SendApplicationForVerification(id), cancellationToken));
        }
    }
}

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

namespace ScienceResearchPA.Controllers
{
    [Route("api/application-submission")]
    [ApiController]
    public class ApplicationSubmission : BaseApiController
    {
        [HttpGet("{page}/{pageSize}")]
        public async Task<ActionResult> Get(int page, int pageSize, [FromQuery] ApplicationQueryParamsDto filterParams, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetApplicationsQuery(page, pageSize, filterParams), cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult<object>>> Post(CreateUpdateApplicationSubmissionCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResult<object>>> Put(CreateUpdateApplicationSubmissionCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}

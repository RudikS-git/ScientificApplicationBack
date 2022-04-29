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
using Microsoft.AspNetCore.Authorization;
using Domain.Entities.Enums;

namespace ScienceResearchPA.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : BaseApiController
    {
        // GET: api/<InnovativeDevelopmentController>
        [HttpGet("{page}/{pageSize}")]
        public async Task<ActionResult> Get([FromQuery] ApplicationQueryParamsDto filterParams, CancellationToken cancellationToken, int page = 1, int pageSize = 15)
        {
            return Ok(await Mediator.Send(new GetApplicationsQuery(page, pageSize, filterParams), cancellationToken));
        }

        // GET api/<InnovativeDevelopmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute]GetApplicationByIdQuery query, CancellationToken cancellationToken)
        {
           return Ok(await Mediator.Send(query, cancellationToken));
        }

        // POST api/<InnovativeDevelopmentController>
        [HttpPost]
        public async Task<ActionResult> Post(CreateApplicationCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        // PUT api/<InnovativeDevelopmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]CreateApplicationCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        // DELETE api/<InnovativeDevelopmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteApplicationByIdCommand(id), cancellationToken));
        }

        [HttpGet("states")]
        public async Task<ActionResult> GetApplicationStates(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetApplicationStatesQuery(), cancellationToken));
        }
    }
}

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
using App.Fields.Commands;

namespace ScienceResearchPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : BaseApiController
    {
        // GET: api/<InnovativeDevelopmentController>
        [HttpGet("{page}/{pageSize}")]
        public async Task<ActionResult> Get(int page, int pageSize, [FromQuery]ApplicationQueryParamsDto filterParams, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetApplicationsQuery(page, pageSize, filterParams), cancellationToken));
        }

        // GET api/<InnovativeDevelopmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<int>>> Get([FromRoute]GetApplicationByIdQuery query, CancellationToken cancellationToken)
        {
           return Ok(await Mediator.Send(query, cancellationToken));
        }

        // POST api/<InnovativeDevelopmentController>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<int>>> Post(CreateApplicationCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        // PUT api/<InnovativeDevelopmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResult<int>>> Put(int id, [FromBody]CreateApplicationCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        // DELETE api/<InnovativeDevelopmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

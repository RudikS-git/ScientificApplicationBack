using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Base;
using System.Threading;
using App.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using App.Common.Models;
using App.Applications.DTOs;
using Mapster;
using MapsterMapper;

using ResponseQuery = App.ApplicationSubmissions.Queries.ApplicationSubmissionQueryDto;

namespace App.ApplicationSubmissions.Queries
{
    public class GetApplicationSubmissionByIdQuery : IRequestWrapper<ResponseQuery>
    {
        public int Id { get; set; }

        public GetApplicationSubmissionByIdQuery(int id)
        {
            this.Id = id;
        }
    }

    public class GetApplicationSubmissionByIdQueryHandler : IRequestHandlerWrapper<GetApplicationSubmissionByIdQuery, ResponseQuery>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userService;

        public GetApplicationSubmissionByIdQueryHandler(IApplicationContext context, IMapper mapper, ICurrentUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<ServiceResult<ResponseQuery>> Handle(GetApplicationSubmissionByIdQuery query, CancellationToken cancellationToken)
        {
            var applicationSubmission = await _context.ApplicationSubmissions.Where(it => it.UserId == _userService.UserId && query.Id == it.Id)
                .OrderByDescending(it => it.Id)
                .FirstOrDefaultAsync();

            if(applicationSubmission == null)
            {
                return ServiceResult.Failed<ResponseQuery>(ServiceError.NotFound);
            }    

            return ServiceResult.Success<ResponseQuery>(_mapper.Map<ApplicationSubmissionQueryDto>(applicationSubmission));
        }
    }
}

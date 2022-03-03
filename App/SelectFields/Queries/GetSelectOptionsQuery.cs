using App.Applications.DTOs;
using App.Common.Interfaces;
using App.Common.Models;
using App.SelectFields.DTOs;
using Domain.Entities.Base.FieldTypes;
using MapsterMapper;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App.SelectFields.Queries
{
    public class GetSelectOptionsQuery : IRequestWrapper<IEnumerable<SelectOptionDto>>
    {
        public int SelectFieldId { get; set; }
        public string Search { get; set; }

        public GetSelectOptionsQuery(int selectFieldId, string search)
        {
            SelectFieldId = selectFieldId;
            Search = search;
        }
    }

    class GetSelectOptionsQueryHandler : IRequestHandlerWrapper<GetSelectOptionsQuery, IEnumerable<SelectOptionDto>>
    {
        private readonly IApplicationContext applicationContext;
        private readonly IStringLocalizer<SharedResource> localizer;
        private readonly IMapper mapper;

        public GetSelectOptionsQueryHandler(IApplicationContext applicationContext, IStringLocalizer<SharedResource> localizer, IMapper mapper)
        {
            this.applicationContext = applicationContext;
            this.localizer = localizer;
            this.mapper = mapper;
        }

        public async Task<ServiceResult<IEnumerable<SelectOptionDto>>> Handle(GetSelectOptionsQuery query, CancellationToken cancellationToken)
        {
            IQueryable<SelectOption> queryable = applicationContext.SelectOptions;

            if(!string.IsNullOrEmpty(query.Search))
            {
                queryable = queryable.Where(it => it.Name.Contains(query.Search));
            }

            var selectOptions = await queryable.ToListAsync();

            if (selectOptions.Count == 0)
            {
                return ServiceResult.Failed<IEnumerable<SelectOptionDto>>(ServiceError.NotFound);
            }

            return ServiceResult.Success(mapper.Map<IEnumerable<SelectOptionDto>>(selectOptions));
        }
    }
}

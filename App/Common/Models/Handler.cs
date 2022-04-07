using App.Common.Interfaces;
using MapsterMapper;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.Models
{
    public class Handler
    {
        protected readonly IApplicationContext _context;
        protected readonly IStringLocalizer<SharedResource> _localizer;
        protected readonly IMapper _mapper;

        public Handler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper)
        {
            this._context = context;
            this._localizer = localizer;
            this._mapper = mapper;
        }
    }

    public class Handler<Poco, DTO>
    {
        protected readonly IApplicationContext _context;
        protected readonly IStringLocalizer<SharedResource> _localizer;
        protected readonly IMapper _mapper;

        public Handler(IApplicationContext context, IStringLocalizer<SharedResource> localizer, IMapper mapper)
        {
            this._context = context;
            this._localizer = localizer;
            this._mapper = mapper;
        }

        protected ServiceResult<DTO> GetSuccessResult(Poco poco)
        {
            return ServiceResult.Success(_mapper.Map<DTO>(poco));
        }

        protected DTO MapToDTO(Poco poco)
        {
            return _mapper.Map<DTO>(poco);
        }
    }
}

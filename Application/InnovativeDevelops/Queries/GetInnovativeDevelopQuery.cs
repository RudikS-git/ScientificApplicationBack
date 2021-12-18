using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.InnovativeDevelops.Queries
{
    public class GetInnovativeDevelopQuery : IRequest<IEnumerable<InnovativeDevelopment>>
    {
        public class GetInnovativeDevelopQueryHandler : IRequestHandler<GetInnovativeDevelopQuery, IEnumerable<InnovativeDevelopment>>
        {
            private readonly ApplicationContext _context;

            public GetInnovativeDevelopQueryHandler(ApplicationContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<InnovativeDevelopment>> Handle(GetInnovativeDevelopQuery query, CancellationToken cancellationToken)
            {
                var innovatives = await _context.InnovativeDevelopments.ToListAsync();

                if (innovatives == null)
                {
                    return null;
                }

                return innovatives.AsReadOnly();
            }
        }
    }
}

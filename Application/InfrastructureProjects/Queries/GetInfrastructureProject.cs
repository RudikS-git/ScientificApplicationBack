using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.InfrastructureProjects.Queries
{
    public class GetInfrastructureProject : IRequest<IEnumerable<InfrastructureProject>>
    {

    }
}

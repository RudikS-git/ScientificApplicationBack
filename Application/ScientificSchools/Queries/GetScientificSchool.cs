using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ScientificSchools.Queries
{
    public class GetScientificSchool : IRequest<IEnumerable<ScientificSchool>>
    {

    }
}

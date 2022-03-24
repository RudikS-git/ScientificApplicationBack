using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Complex
{
    [Owned]
    public class FieldStyle
    {
        public int Order { get; set; }
    }
}

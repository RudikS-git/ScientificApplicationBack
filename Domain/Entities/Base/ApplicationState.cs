using Domain.Entities.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class ApplicationState : BaseListEntity
    {
        public ApplicationStatesEnum Id { get; set; }
    }
}

using Domain.Entities.Common;
using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class Application : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string SystemName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Permission Permission { get; set; } // доступ по правам
        public bool IsRemoved { get; set; }
        
        public IList<ApplicationGroup> ApplicationGroups { get; set; }
        public IList<ApplicationSubmission> ApplicationSubmissions { get; set; }

        public ManageApplicationStates ManageApplicationState { get; set; }
    }
}

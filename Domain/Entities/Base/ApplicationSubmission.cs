using Domain.Entities.Base.FieldSubmissions;
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class ApplicationSubmission : AuditableBaseEntity
    {
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public string Name { get; set; }

        public ApplicationState ApplicationState { get; set; }
        public List<HistoryApplicationState> HistoryApplicationStates { get; set; }

        public bool IsRemoved { get; set; }

        public List<InputSubmission> InputSubmissions { get; set; }
        public List<SelectSubmission> SelectSubmissions { get; set; }
    }
}

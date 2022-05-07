using Domain.Entities.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class HistoryApplicationState : AuditableBaseEntity
    {
        public ApplicationStatesEnum LastApplicationStateId { get; set; }
        public ApplicationState LastApplicationState { get; set; }

        public ApplicationStatesEnum NewApplicationStateId { get; set; }
        public ApplicationState NewApplicationState { get; set; }
        public string Comment { get; set; }

        public int ApplicationSubmissionId { get; set; }
        public ApplicationSubmission ApplicationSubmission { get; set; }

        public int ChangedUserId { get; set; }
        public User ChangedUser { get; set; }
    }
}
  
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class HistoryApplicationState : BaseEntity
    {
        public DateTime Creation { get; set; }
        public ApplicationState LastApplicationState { get; set; }
        public ApplicationState NewApplicationState { get; set; }
        public User ChangedUser { get; set; }
    }
}

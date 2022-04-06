using Domain.Entities.Base.FieldTypes;
using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base.FieldSubmissions
{
    public class SelectSubmissonOptions : BaseEntity
    {
        public int SelectSubmissionId { get; set; }
        public SelectSubmission SelectSubmission { get; set; }

        public int SelectOptionId { get; set; }
        public SelectOption SelectOption { get; set; }
    }
}

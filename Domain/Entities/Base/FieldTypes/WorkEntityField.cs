using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Base.FieldTypes
{
    [Table("WorkEntityField")]
    public class WorkEntityField : BaseEntity
    {
        public int FieldSubmissionId { get; set; }
        public FieldSubmission FieldSubmission { get; set; }

        public int FieldTypeId { get; set; }
        public FieldType FieldType { get; set; }

        public string Label { get; set; }
        public List<FieldSubmission> FieldSubmissions { get; set; }
    }
}

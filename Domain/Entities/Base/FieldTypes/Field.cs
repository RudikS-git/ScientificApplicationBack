using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public abstract class Field : BaseEntity
    {
        public int FieldSubmissionId { get; set; }
        public FieldSubmission FieldSubmission { get; set; }

        public int ApplicationGroupId { get; set; }
        public ApplicationGroup ApplicationGroup { get; set; }

        public int FieldTypeId { get; set; }
        public FieldType FieldType { get; set; }

        public bool IsRequired { get; set; }
        public string Label { get; set; }
        public string SystemName { get; set; }
        public string Description { get; set; }
    }
}

using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Grant : BaseEntity
    {
        public string Name { get; set; }

        public Member Leader { get; set; }

        public DateTime Period { get; set; }

        public string SourceOfFinancing { get; set; }

        public string FundingVolume { get; set; }
    }
}

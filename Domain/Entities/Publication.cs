using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Publication : BaseEntity
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public string Authors { get; set; }

        public DateTime Year { get; set; }

        public string DOI { get; set; }

        public string Link { get; set; }

        public string Quartile { get; set; }
    }
}

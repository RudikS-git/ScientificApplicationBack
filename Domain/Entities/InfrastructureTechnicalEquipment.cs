using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class InfrastructureTechnicalEquipment : BaseEntity
    {
        public InfrastructureTypeEquipment InfrastructureTypeEquipment { get; set; }

        public string Name { get; set; }

        public DateTime Year { get; set; }

        public string Manufacturer { get; set; }

        public string ApplicationArea { get; set; }
    }
}

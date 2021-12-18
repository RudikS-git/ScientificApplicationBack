using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class InfrastructureProject : BaseEntity
    {
        public ApplicationState ApplicationState { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ResearchDirection ResearchDirection { get; set; }
        public InfrastructureScientificLeader ScienceLeader { get; set; }
        public InfrastructureTechnicalLeader TechnicalLeader { get; set; }
        public List<InfrastructurePhoto> InfrastructurePhotos { get; set; }
        public List<InfrastructureCustomer> InfrastructureCustomers { get; set; }
        public List<InfrastructureProjectRealization> InfrastructureProjectRealizations { get; set; }
        public List<InfrastructureResearch> InfrastructureResearches { get; set; }
        public List<InfrastructureTechnicalEquipment> InfrastructureTechnicalEquipment { get; set; }
        public List<InfrastructureServiceProvided> ServiceProvideds { get; set; }
        public List<InfrastructureSpecialist> InfrastructureSpecialists { get; set; }

    }
}

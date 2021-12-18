using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class InnovativeDevelopment : BaseEntity
    {
        public ApplicationState ApplicationState { get; set; }
        public string Name { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public List<InnovativeDepartment> Departments { get; set; }
        public List<InnovativeBranch> Branches { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public BranchScience BranchScience { get; set; }
        public PriorityDirection PriorityDirection { get; set; }
        public CriticalTechnology CriticalTechnology { get; set; }
        public TypeResearch TypeResearch { get; set; }
        public Efficiency Efficiency { get; set; }
        public List<GRNTI> GRNTI { get; set; }
        public string Appointment { get; set; }
        public string ApplicationArea { get; set; }
        public string Specifications { get; set; }
        public ReadinessDegree ReadinessDegree { get; set; }
        public string SignsOfTechnicalSolution { get; set; }
        public string PositiveResult { get; set; }
        public string MethodOfApplication { get; set; }
        public string Competitiveness { get; set; }
        public string EconomicEffect { get; set; }
        public string ImplementationExperience { get; set; }
        public string SourcesOfFinancing { get; set; }
        public List<InnovativeLeader> InnovativeLeaders { get; set; }
        public List<InnovativeMember> InnovativeMembers { get; set; }
        public List<FullScaleSample> FullScaleSamples { get; set; }
        public List<PresentationMaterial> PresentationMaterials { get; set; }
        public List<Patent> Patents { get; set; }
    }
}

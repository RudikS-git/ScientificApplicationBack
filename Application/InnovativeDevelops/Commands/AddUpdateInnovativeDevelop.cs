using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.InnovativeDevelops.Commands
{
    public class AddUpdateInnovativeDevelopCommand : IRequest<int>
    {
        public int Id { get; set; }
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

        public class AddUpdateInnovativeDevelopHandler : IRequestHandler<AddUpdateInnovativeDevelopCommand, int>
        {
            private readonly ApplicationContext context;

            public AddUpdateInnovativeDevelopHandler(ApplicationContext applicationContext)
            {
                context = applicationContext;
            }

            public async Task<int> Handle(AddUpdateInnovativeDevelopCommand command, CancellationToken cancellationToken)
            {
                var innovative = new InnovativeDevelopment()
                {
                    Id = command.Id,
                    ApplicationState = command.ApplicationState,
                    StartWork = command.StartWork,
                    EndWork = command.EndWork,
                    Departments = command.Departments,
                    Branches = command.Branches,
                    Email = command.Email,
                    Phone = command.Phone,
                    BranchScience = command.BranchScience,
                    PriorityDirection = command.PriorityDirection,
                    CriticalTechnology = command.CriticalTechnology,
                    TypeResearch = command.TypeResearch,
                    Efficiency = command.Efficiency,
                    GRNTI = command.GRNTI,
                    Appointment = command.Appointment,
                    ApplicationArea = command.ApplicationArea,
                    Specifications = command.Specifications,
                    ReadinessDegree = command.ReadinessDegree,
                    SignsOfTechnicalSolution = command.SignsOfTechnicalSolution,
                    PositiveResult = command.PositiveResult,
                    MethodOfApplication = command.MethodOfApplication,
                    Competitiveness = command.Competitiveness,
                    EconomicEffect = command.EconomicEffect,
                    ImplementationExperience = command.ImplementationExperience,
                    SourcesOfFinancing = command.SourcesOfFinancing,
                    InnovativeLeaders = command.InnovativeLeaders,
                    InnovativeMembers = command.InnovativeMembers,
                    FullScaleSamples = command.FullScaleSamples,
                    PresentationMaterials = command.PresentationMaterials,
                    Patents = command.Patents
                };

                if(innovative.Id != 0) // update
                {
                    context.InnovativeDevelopments.Update(innovative);
                }
                else // create
                {
                    await context.InnovativeDevelopments.AddAsync(innovative);
                }

                await context.SaveChangesAsync();

                return innovative.Id;
            }
        }
        
        

    }
}

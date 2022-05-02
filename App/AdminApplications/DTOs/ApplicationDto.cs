using Domain.Entities.Base;
using Domain.Entities.Enums;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AdminApplications.DTOs
{
    public class ApplicationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public ManageApplicationStates ManageApplicationState { get; set; }

        public void Register(TypeAdapterConfig config)
        {

        }
    }
}

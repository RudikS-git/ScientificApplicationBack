using App.ApplicationSubmissions.DTOs;
using Domain.Entities.Base;
using Domain.Entities.Base.FieldSubmissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationSubmissions.Queries
{
    public class ApplicationSubmissionQueryDetailsDto
    {
        public string Name { get; set; }

        public ApplicationState ApplicationState { get; set; }
        public List<HistoryApplicationState> HistoryApplicationStates { get; set; }

        public bool IsRemoved { get; set; }

        public List<InputSubmission> InputSubmissions { get; set; }
        public List<SelectSubmission> SelectSubmissions { get; set; }
    }
}

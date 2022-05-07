using Domain.Entities.Base;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.HistorySubmissionApplications.DTOs
{
    public class HistorySubmissionDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public ApplicationState LastApplicationState { get; set; }
        public ApplicationState NewApplicationState { get; set; }
        public string Comment { get; set; }
    }
}

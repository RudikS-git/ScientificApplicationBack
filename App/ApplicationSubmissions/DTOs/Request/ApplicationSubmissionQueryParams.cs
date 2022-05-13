using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationSubmissions.DTOs.Request
{
    public class ApplicationSubmissionQueryParams
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ApplicationStatesEnum? applicationState { get; set; }
    }
}

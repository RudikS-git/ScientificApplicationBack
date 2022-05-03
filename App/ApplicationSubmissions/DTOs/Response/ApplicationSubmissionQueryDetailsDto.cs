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
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string Name { get; set; }
        public ApplicationState ApplicationState { get; set; }
        public List<InputSubmisionDto> InputSubmissions { get; set; }
        public List<SelectSubmissionDto> SelectSubmissions { get; set; }
    }
}

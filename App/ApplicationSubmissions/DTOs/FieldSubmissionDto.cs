using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ApplicationSubmissions.DTOs
{
    public class FieldSubmissionDto
    {
        public int SubmissionId { get; set; }
        public ApplicationSubmission Submission { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applications.DTOs
{
    public class ApplicationDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ApplicationGroupDto> ApplicationGroups { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PensionManagementSystem.Application.Entities;

namespace PensionManagementSystem.Application.Dtos
{
    public class EmployerDto : BaseDto
    {
        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}

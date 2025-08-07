using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PensionManagementSystem.Application.Entities;

namespace PensionManagementSystem.Application.Dtos
{
    public class MemberDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Guid EmployerId { get; set; }
        public ICollection<Contribution> Contributions { get; set; }
    }
}

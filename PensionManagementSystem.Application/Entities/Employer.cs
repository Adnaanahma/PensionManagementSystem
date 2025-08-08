using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementSystem.Application.Entities
{
    public class Employer : BaseEntity
    {
        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}

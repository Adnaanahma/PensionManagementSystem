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
        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[A-Z0-9]{6,20}$", ErrorMessage = "Invalid registration number format.")]
        public string RegistrationNumber { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}

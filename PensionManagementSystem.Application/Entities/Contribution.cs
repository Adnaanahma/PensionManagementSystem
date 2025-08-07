using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PensionManagementSystem.Application.Enums;

namespace PensionManagementSystem.Application.Entities
{
    public class Contribution : BaseEntity
    {
        public ContributionType ContributionType { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime ContributionDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string ReferenceNumber { get; set; }

        public Guid MemberId { get; set; } // Foreign Key to Member
    }
}

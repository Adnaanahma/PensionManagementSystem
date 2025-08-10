using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PensionManagementSystem.Application.Enums;

namespace PensionManagementSystem.Application.Dtos
{
    public class BenefitDto : BaseDto
    {
        public BenefitType BenefitType { get; set; }

        public bool EligibilityStatus { get; set; }

        public decimal Amount { get; set; }
        public DateTime DateGranted { get; set; }
        public Guid MemberId { get; set; } 

        public DateTime CalculationDate { get; set; }
    }
}

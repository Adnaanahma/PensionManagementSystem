using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PensionManagementSystem.Application.Enums;

namespace PensionManagementSystem.Application.ViewModels
{
    public class BenefitRequestModel
    {
        public BenefitType BenefitType { get; set; }

        public bool EligibilityStatus { get; set; }

        public decimal Amount { get; set; }  // validated in the validator folder
        public Guid MemberId { get; set; }  // Foreign Key to Member

        public DateTime CalculationDate { get; set; }
    }
}

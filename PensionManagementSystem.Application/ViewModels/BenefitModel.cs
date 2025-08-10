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
        public Guid MemberId { get; set; }
        public decimal Amount { get; set; }
    }
}

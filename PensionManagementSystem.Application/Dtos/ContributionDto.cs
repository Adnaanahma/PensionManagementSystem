using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PensionManagementSystem.Application.Enums;

namespace PensionManagementSystem.Application.Dtos
{
    public class ContributionDto : BaseDto
    {
        public ContributionType ContributionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ContributionDate { get; set; }
        public string ReferenceNumber { get; set; }

        public Guid MemberId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PensionManagementSystem.Application.Dtos;
using PensionManagementSystem.Application.ViewModels;

namespace PensionManagementSystem.Domain.Interfaces
{
    public interface IBenefitService
    {
        Task<Guid> AddBenefitAsync(BenefitRequestModel model);
        Task<BenefitDto> CalculateBenefitAsync(Guid memberId);
        IEnumerable<BenefitDto> GetBenefitsByMemberId(Guid memberId);
    }
}

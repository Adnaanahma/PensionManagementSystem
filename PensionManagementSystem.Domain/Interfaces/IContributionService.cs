using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PensionManagementSystem.Application.Dtos;
using PensionManagementSystem.Application.ViewModels;

namespace PensionManagementSystem.Domain.Interfaces
{
    public interface IContributionService
    {
        Task<Guid> AddContributionAsync(ContributionRequestModel model);
        IEnumerable<ContributionDto> GetByMemberId(Guid memberId);
    }
}

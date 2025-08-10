using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arch.EntityFrameworkCore.UnitOfWork;
using PensionManagementSystem.Application.Dtos;
using PensionManagementSystem.Application.Entities;
using PensionManagementSystem.Application.ViewModels;
using PensionManagementSystem.Domain.Interfaces;

namespace PensionManagementSystem.Domain.Services
{
    public class ContributionService : IContributionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContributionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> AddContributionAsync(ContributionRequestModel model)
        {
            var contribution = new Contribution
            {
                Id = Guid.NewGuid(),
                MemberId = model.MemberId,
                Amount = model.Amount,
                ContributionDate = DateTime.UtcNow,
                IsActive = true
            };

            await _unitOfWork.GetRepository<Contribution>().InsertAsync(contribution);
            await _unitOfWork.SaveChangesAsync();

            return contribution.Id;
        }

        public IEnumerable<ContributionDto> GetByMemberId(Guid memberId)
        {
            var contributions = _unitOfWork.GetRepository<Contribution>()
                .GetAll()
                .Where(c => c.MemberId == memberId && c.IsActive);

            return contributions.Select(c => new ContributionDto
            {
                Id = c.Id,
                Amount = c.Amount,
                ContributionDate = c.ContributionDate
            });
        }
    }

}

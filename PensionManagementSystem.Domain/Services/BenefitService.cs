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
    public class BenefitService : IBenefitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IContributionService _contributionService;

        public BenefitService(IUnitOfWork unitOfWork, IContributionService contributionService)
        {
            _unitOfWork = unitOfWork;
            _contributionService = contributionService;
        }

        public async Task<Guid> AddBenefitAsync(BenefitRequestModel model)
        {
            var benefit = new Benefit
            {
                Id = Guid.NewGuid(),
                MemberId = model.MemberId,
                Amount = model.Amount,
                DateGranted = DateTime.UtcNow,
                IsActive = true
            };

            await _unitOfWork.GetRepository<Benefit>().InsertAsync(benefit);
            await _unitOfWork.SaveChangesAsync();

            return benefit.Id;
        }

        public async Task<BenefitDto> CalculateBenefitAsync(Guid memberId)
        {
            var contributions = _contributionService.GetByMemberId(memberId);
            var totalContributed = contributions.Sum(c => c.Amount);

            // Example formula: 60% of total contributions
            var benefitAmount = totalContributed * 0.6m;

            return new BenefitDto
            {
                MemberId = memberId,
                Amount = benefitAmount,
                CalculationDate = DateTime.UtcNow
            };
        }

        public IEnumerable<BenefitDto> GetBenefitsByMemberId(Guid memberId)
        {
            var benefits = _unitOfWork.GetRepository<Benefit>()
                .GetAll()
                .Where(b => b.MemberId == memberId && b.IsActive);

            return benefits.Select(b => new BenefitDto
            {
                Id = b.Id,
                MemberId = b.MemberId,
                Amount = b.Amount,
                DateGranted = b.DateGranted
            });
        }
    }

}

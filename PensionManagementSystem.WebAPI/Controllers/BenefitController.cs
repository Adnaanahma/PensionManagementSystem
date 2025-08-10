using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PensionManagementSystem.Application.ViewModels;
using PensionManagementSystem.Domain.Interfaces;

namespace PensionManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/benefits")]
    public class BenefitController : ControllerBase
    {
        private readonly IBenefitService _benefitService;

        public BenefitController(IBenefitService benefitService)
        {
            _benefitService = benefitService;
        }

        /// <summary>
        /// Add a new benefit for a member
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddBenefit([FromBody] BenefitRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var benefitId = await _benefitService.AddBenefitAsync(model);
            return CreatedAtAction(nameof(GetBenefitsByMemberId), new { memberId = model.MemberId }, new { BenefitId = benefitId });
        }

        /// <summary>
        /// Calculate benefit based on member's contributions
        /// </summary>
        [HttpGet("calculate/{memberId}")]
        public async Task<IActionResult> CalculateBenefit(Guid memberId)
        {
            var benefit = await _benefitService.CalculateBenefitAsync(memberId);
            return Ok(benefit);
        }

        /// <summary>
        /// Get all benefits for a member
        /// </summary>
        [HttpGet("member/{memberId}")]
        public IActionResult GetBenefitsByMemberId(Guid memberId)
        {
            var benefits = _benefitService.GetBenefitsByMemberId(memberId);
            return Ok(benefits);
        }

    }
}

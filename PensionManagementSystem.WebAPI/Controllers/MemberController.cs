using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PensionManagementSystem.Application.ViewModels;
using PensionManagementSystem.Domain.Interfaces;
using PensionManagementSystem.Domain.Services;

namespace PensionManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/members")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost]
        [Authorize] // Only employer can create
        public async Task<IActionResult> CreateMember([FromBody] MemberRequestModel model)
        {
            var id = await _memberService.CreateMemberAsync(model);
            return Ok(new { MemberId = id });
        }

        [HttpGet]
        [Authorize] // Only employer can view all
        public IActionResult GetAllMembers()
        {
            var members = _memberService.GetAllMembers();
            return Ok(members);
        }

        [HttpGet("{id}")]
        [AllowAnonymous] // Public access
        public async Task<IActionResult> GetMemberById(Guid id)
        {
            var member = await _memberService.GetMemberByIdAsync(id);
            return Ok(member);
        }

        [HttpPut("{id}")]
        [AllowAnonymous] // Public access
        public async Task<IActionResult> UpdateMember(Guid id, [FromBody] MemberRequestModel model)
        {
            await _memberService.UpdateMemberAsync(id, model);
            return Ok(new { message = "Member updated successfully" });
        }

        [HttpDelete("{id}")]
        [Authorize] // Only employer can delete
        public async Task<IActionResult> SoftDeleteMember(Guid id)
        {
            await _memberService.SoftDeleteMemberAsync(id);
            return Ok(new { message = "Member deleted successfully" });
        }
    }

}

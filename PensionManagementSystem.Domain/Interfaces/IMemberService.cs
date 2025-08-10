using PensionManagementSystem.Application.Dtos;
using PensionManagementSystem.Application.ViewModels;

namespace PensionManagementSystem.Domain.Interfaces
{
    public interface IMemberService
    {
        Task<Guid> CreateMemberAsync(MemberRequestModel model);
        Task UpdateMemberAsync(Guid id, MemberRequestModel model);
        Task<MemberDto> GetMemberByIdAsync(Guid id);
        IEnumerable<MemberDto> GetAllMembers();
        Task SoftDeleteMemberAsync(Guid id);
    }
}

using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using PensionManagementSystem.Application.Dtos;
using PensionManagementSystem.Application.Entities;
using PensionManagementSystem.Application.ViewModels;
using PensionManagementSystem.Domain.Interfaces;

namespace PensionManagementSystem.Domain.Services
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new member
        /// </summary>
        public async Task<Guid> CreateMemberAsync(MemberRequestModel model)
        {
            try
            {
                var member = new Member
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    EmployerId = model.EmployerId,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                };

                await _unitOfWork.GetRepository<Member>().InsertAsync(member);
                await _unitOfWork.SaveChangesAsync();

                return member.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating member: {ex.Message}");
            }
        }

        /// <summary>
        /// Update an existing member
        /// </summary>
        public async Task UpdateMemberAsync(Guid id, MemberRequestModel model)
        {
            try
            {
                var member = await _unitOfWork.GetRepository<Member>().GetFirstOrDefaultAsync(x => x.Id == id, null, null, false);
                if (member == null) throw new Exception("Member not found");

                member.FirstName = model.FirstName ?? member.FirstName;
                member.LastName = model.LastName ?? member.LastName;
                member.DateOfBirth = model.DateOfBirth;
                member.PhoneNumber = model.PhoneNumber ?? member.PhoneNumber;
                member.Email = model.Email ?? member.Email;
                member.UpdatedAt = DateTime.UtcNow;

                _unitOfWork.GetRepository<Member>().Update(member);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating member: {ex.Message}");
            }
        }

        /// <summary>
        /// Get member by ID (returns DTO)
        /// </summary>
        public async Task<MemberDto> GetMemberByIdAsync(Guid id)
        {
            try
            {
                var member = await _unitOfWork.GetRepository<Member>().GetFirstOrDefaultAsync(x => x.Id == id, null, null, false);
                if (member == null) throw new Exception("Member not found");

                return _mapper.Map<MemberDto>(member);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving member: {ex.Message}");
            }
        }

        /// <summary>
        /// Get all members (returns DTO list)
        /// </summary>
        public IEnumerable<MemberDto> GetAllMembers()
        {
            try
            {
                var members = _unitOfWork.GetRepository<Member>().GetAll(); 
                return _mapper.Map<IEnumerable<MemberDto>>(members);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving members: {ex.Message}");
            }
        }


        /// <summary>
        /// Soft delete a member
        /// </summary>
        public async Task SoftDeleteMemberAsync(Guid id)
        {
            try
            {
                var member = await _unitOfWork.GetRepository<Member>().GetFirstOrDefaultAsync(x => x.Id == id, null, null, false);
                if (member == null) throw new Exception("Member not found");

                member.IsActive = false;
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting member: {ex.Message}");
            }
        }
    }

}

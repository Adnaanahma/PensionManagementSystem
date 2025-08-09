using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using PensionManagementSystem.Application.Dtos;
using PensionManagementSystem.Application.Entities;
using PensionManagementSystem.Application.ViewModels;
using PensionManagementSystem.Domain.Interfaces;

namespace PensionManagementSystem.Domain.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new employer
        /// </summary>
        public async Task<Guid> CreateEmployerAsync(EmployerRequestModel model)
        {
            try
            {
                var employer = new Employer
                {
                    Id = Guid.NewGuid(),
                    CompanyName = model.CompanyName,
                    RegistrationNumber = model.RegistrationNumber,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                };

                await _unitOfWork.GetRepository<Employer>().InsertAsync(employer);
                await _unitOfWork.SaveChangesAsync();

                return employer.Id;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating employer: {ex.Message}");
            }
        }

        /// <summary>
        /// Get employer by ID
        /// </summary>
        public async Task<EmployerDto> GetEmployerByIdAsync(Guid id)
        {
            try
            {
                var employer = await _unitOfWork.GetRepository<Employer>().GetFirstOrDefaultAsync(x => x.Id == id, null, null, false);
                if (employer == null) throw new Exception("Employer not found");

                return _mapper.Map<EmployerDto>(employer);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving employer: {ex.Message}");
            }
        }

        /// <summary>
        /// Get all employers
        /// </summary>
        public IEnumerable<EmployerDto> GetAllEmployers()
        {
            try
            {
                var employers = _unitOfWork.GetRepository<Employer>().GetAll();
                return _mapper.Map<IEnumerable<EmployerDto>>(employers);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving employers: {ex.Message}");
            }
        }

        /// <summary>
        /// Update employer details
        /// </summary>
        public async Task UpdateEmployerAsync(Guid id, EmployerRequestModel model)
        {
            try
            {
                var employer = await _unitOfWork.GetRepository<Employer>().GetFirstOrDefaultAsync(x => x.Id == id, null, null, false);
                if (employer == null) throw new Exception("Employer not found");

                employer.CompanyName = model.CompanyName;
                employer.RegistrationNumber = model.RegistrationNumber;
                employer.UpdatedAt = DateTime.UtcNow;

                _unitOfWork.GetRepository<Employer>().Update(employer);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating employer: {ex.Message}");
            }
        }

    }

}

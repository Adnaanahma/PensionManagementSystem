using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PensionManagementSystem.Application.Dtos;
using PensionManagementSystem.Application.ViewModels;

namespace PensionManagementSystem.Domain.Interfaces
{
    public interface IEmployerService
    {
        Task<Guid> CreateEmployerAsync(EmployerRequestModel model);
        Task<EmployerDto> GetEmployerByIdAsync(Guid id);
        IEnumerable<EmployerDto> GetAllEmployers();
        Task UpdateEmployerAsync(Guid id, EmployerRequestModel model);
    }
}

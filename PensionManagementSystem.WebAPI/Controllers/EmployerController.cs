using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PensionManagementSystem.Application.ViewModels;
using PensionManagementSystem.Domain.Interfaces;

namespace PensionManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/employers")]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _employerService;

        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }
        /// <summary>
        /// Create Employer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous] // Public registration
        public async Task<IActionResult> CreateEmployer([FromBody] EmployerRequestModel model)
        {
            var id = await _employerService.CreateEmployerAsync(model);
            return Ok(new { EmployerId = id });
        }
        /// <summary>
        /// Get All Employers...Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize] // Only authenticated users
        public IActionResult GetAllEmployers()
        {
            var employers = _employerService.GetAllEmployers();
            return Ok(employers);
        }
        /// <summary>
        /// Get Employer By Id ... Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetEmployerById(Guid id)
        {
            var employer = await _employerService.GetEmployerByIdAsync(id);
            return Ok(employer);
        }
        /// <summary>
        /// Update Employer  ...Admin
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateEmployer(Guid id, [FromBody] EmployerRequestModel model)
        {
            await _employerService.UpdateEmployerAsync(id, model);
            return Ok(new { message = "Member updated successfully" });
        }

       
    }

}

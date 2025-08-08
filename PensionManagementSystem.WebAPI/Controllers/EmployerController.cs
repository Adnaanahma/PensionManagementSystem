using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PensionManagementSystem.Application.ViewModels;

namespace PensionManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/employers")]
    public class EmployerController : ControllerBase
    {
        private readonly EmployerService _employerService;

        public EmployerController(EmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpPost]
        [AllowAnonymous] // Public registration
        public async Task<IActionResult> CreateEmployer([FromBody] EmployerRequestModel model)
        {
            var id = await _employerService.CreateEmployerAsync(model);
            return Ok(new { EmployerId = id });
        }

        [HttpGet]
        [Authorize] // Only authenticated users
        public IActionResult GetAllEmployers()
        {
            var employers = _employerService.GetAllEmployers();
            return Ok(employers);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetEmployerById(Guid id)
        {
            var employer = await _employerService.GetEmployerByIdAsync(id);
            return Ok(employer);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateEmployer(Guid id, [FromBody] EmployerRequestModel model)
        {
            await _employerService.UpdateEmployerAsync(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Only Admin can delete
        public async Task<IActionResult> SoftDeleteEmployer(Guid id)
        {
            await _employerService.SoftDeleteEmployerAsync(id);
            return NoContent();
        }
    }

}

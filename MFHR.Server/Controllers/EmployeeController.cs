using MF.HR;
using MF.HR.DTO;
using MF.HR.Entity;
using MF.HR.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MF.HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(ILogger<EmployeeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [HttpPost("CreateNewEmployee")]
        public async Task<IActionResult> CreateNewEmployee(Employee req)
        {

            try
            {
                var result = await _unitOfWork.Employees.AddEmployeeAsync(req);

                if (result > 0)
                {
                    return Ok(new { success = true, message = "Employee added successfully" });
                }
                else
                {
                    return Ok(new { success = false, message = "Failed to add employee" });
                }
            }
            catch (Exception e)
            {
                return Ok(new { success = false, message = "An excption occsured, Failed to add employee" });
            }
        }


        [AllowAnonymous]
        [HttpPost("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee req)
        {

            try
            {
                var result = await _unitOfWork.Employees.UpdateEmployeeAsync(req);

                if (result > 0)
                {
                    return Ok(new { success = true, message = "Employee updated successfully" });
                }
                else
                {
                    return Ok(new { success = false, message = "Failed to update employee" });
                }
            }
            catch (Exception e)
            {
                return Ok(new { success = false, message = "An excption occsured, Failed to update employee" });
            }
        }


        [AllowAnonymous]
        [HttpGet("GetByEmployeeId")]
        public async Task<IActionResult> GetByEmployeeId(int id)
        {
            try
            {
                var result = await _unitOfWork.Employees.GetByEmployeeIdAsync(id);

                if (result  != null)
                {
                    return Ok(new { success = true, message = "",entity = result });
                }
                else
                {
                    return Ok(new { success = false, message = "Failed to retrieve employee" });
                }
            }
            catch (Exception e)
            {
                return Ok(new { success = false, message = "An exception occsured, Failed to retrieve employee" });
            }
        }


        [AllowAnonymous]
        [HttpGet("GetAllActiveEmployees")]
        public async Task<IActionResult> GetAllActiveEmployees(int rows)
        {
            try
            {
                var result =  await _unitOfWork.Employees.GetAllActiveEmployeesAsync();

                if (result.Count > 0)
                {
                    return Ok(new { success = true, message = "", entity = result });
                }
                else
                {
                    return Ok(new { success = false, message = "Failed to retrieve employees" });
                }
            }
            catch (Exception e)
            {
                return Ok(new { success = false, message = "An exception occsured, Failed to retrieve employee" });
            }
        }
    }
}

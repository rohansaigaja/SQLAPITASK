using EmpSqlTask.Data;
using EmpSqlTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpSqlTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateSalaryByEmp : Controller
    {
        private readonly EmployeeDbContext dbContext;
        public UpdateSalaryByEmp(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        [HttpPut]

        public IActionResult UpdateSalariesDepartmentWise(int empid, decimal percentage)
        {
            try
            {
                dbContext.Database.ExecuteSqlRaw($"UpdateEmployeeSalary {empid},{percentage}");
                dbContext.SaveChanges();
                //var data = _dbcontext.EmpSalaries.ToList();
                // var data = dbContext.GetEmployeesByDepartment.FromSqlRaw($"EXEC UpdateSalariesByDepartment {DeptId}");
                return Ok();
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return new ObjectResult("Internal Database error");
            }

        }
    }
}

using EmpSqlTask.Data;
using EmpSqlTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpSqlTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateInfoByDepartment : Controller
    {
        private readonly EmployeeDbContext dbContext;
        public UpdateInfoByDepartment(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        [HttpPut]

        public IActionResult UpdateSalariesDepartmentWise(int deptid, decimal percentage)
        {
            try
            {
                dbContext.Database.ExecuteSqlRaw($"UpdateSalariesByDepartment {deptid},{percentage}");
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

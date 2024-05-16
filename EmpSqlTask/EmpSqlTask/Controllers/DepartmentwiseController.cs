using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmpSqlTask.Data;
using EmpSqlTask.Models;

namespace EmpSqlTask.Controllers {
    [ApiController]
    [Route("api/[controller]")]

    public class DepartmentwiseController : Controller
    {
        private readonly EmployeeDbContext dbContext;
        public DepartmentwiseController(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;

        }


        [HttpGet(Name = "Get number of employees ands sum of salaries in each department")]

        public IActionResult GetEmpDeptWise()
        {
            
                var data = dbContext.GetEmployeesDepartmentWise.FromSqlRaw("EXEC GetEmployeeSummaryByDepartment");
                return Ok(data);
            
            /*catch (Exception)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return new ObjectResult("Internal Database error");
            }*/

        }
    }
}

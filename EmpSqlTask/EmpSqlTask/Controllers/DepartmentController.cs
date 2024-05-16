using EmpSqlTask.Data;
using EmpSqlTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmpSqlTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private readonly EmployeeDbContext dbContext;
        public DepartmentController(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;

        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentData()
        {
           return Ok( await dbContext.department.ToListAsync());
            
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(DepartmentRequestModel departRequestModel)
        {
            var depart = new Department()
            {
                deptid = 12,
                deptname = departRequestModel.deptname,
                ManagerId= departRequestModel.ManagerId

            };
            await dbContext.AddAsync(depart);
            await dbContext.SaveChangesAsync();
            return Ok(depart);


        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, DepartmentRequestModel departRequestModel)
        {
            var depart = await dbContext.department.FindAsync(id);
            if (depart != null)
            {
                depart.deptname = departRequestModel.deptname;
                depart.ManagerId = departRequestModel.ManagerId;
                await dbContext.SaveChangesAsync();
                return Ok(depart);

            }
            return NotFound();

        }
    }
    
}

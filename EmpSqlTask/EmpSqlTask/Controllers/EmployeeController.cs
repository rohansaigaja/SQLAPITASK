using EmpSqlTask.Data;
using EmpSqlTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace EmpSqlTask.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext dbContext;
        public EmployeeController(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeeData()
        {
            return Ok(await dbContext.employ.FromSqlInterpolated($"exec GetEmployeeList").
                ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeRequestModel employeeRequestModel)
        {
            int? maxid = dbContext.employ.Max(e => e.empid);
            if (maxid == null)
                maxid = 0;
            var employe = new Employee()
            {
                empid = (int)++maxid,
                empname = employeeRequestModel.empname,
                deptid = employeeRequestModel.deptid

            };
            await dbContext.employ.AddAsync(employe);
            await dbContext.SaveChangesAsync();
            return Ok(employe);


        }
        [HttpPut]
        [Route("{empid:int}")]
        public async Task<IActionResult> UpdateEmployee(int empid, EmployeeRequestModel employeeRequestModel)
        {
            var employe = await dbContext.employ.FindAsync(empid);
            if (employe != null)
            {
                employe.empname = employeeRequestModel.empname;
                employe.deptid = employeeRequestModel.deptid;
                await dbContext.SaveChangesAsync();
                return Ok(employe);

            }
            return NotFound();

        }
        [HttpGet]
        [Route("api/employees")]
        public IActionResult GetEmployeesListWithDeptNameSalary()
        {
            try
            {

                var data = dbContext.GetEmplys.FromSqlRaw("EXEC GetEmployeeListSalary");
                return Ok(data);
            }
            catch (Exception)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return new ObjectResult("Internal Database error");
            }
        }
        [HttpDelete]
        [Route("{empid:int}")]
        public IActionResult DeleteDepartment([FromRoute] int empid)
        {
            /*  var empsalary = dbContext.employ.Find(empid);

              if (empsalary == null)
                  return NotFound();

              dbContext.employ.Remove(empsalary);
              dbContext.SaveChanges();
              return Ok("Employee  deleted");
            */
            var employeeToDelete = dbContext.employ.Find(empid);
           // var employsalarytodelete = dbContext.employsalary.Find(empid);


            if (employeeToDelete == null)
            {
                return NotFound();
            }

           
                dbContext.Database.BeginTransaction();

                
                var departmentsWithManagerId = dbContext.department
                    .Where(d => d.ManagerId == empid)
                    .ToList();
                if (departmentsWithManagerId != null)
                {

                    foreach (var department in departmentsWithManagerId)
                    {
                        department.ManagerId = null;
                        

                    }

                    
                    
               // dbContext.employsalary.Remove(employsalarytodelete);
                dbContext.employ.Remove(employeeToDelete);


                
                dbContext.SaveChanges();

                   
                    dbContext.Database.CommitTransaction();

                    return Ok("Employee deleted");
                }
                else
                {
                //dbContext.employsalary.Remove(employsalarytodelete);
                dbContext.employ.Remove(employeeToDelete);
                   

                    
                    dbContext.SaveChanges();

                   
                    dbContext.Database.CommitTransaction();

                    return Ok("Employee deleted");
                }
            
            

        }







    }


}






    



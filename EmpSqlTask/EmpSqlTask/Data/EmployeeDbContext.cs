using EmpSqlTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Query;

namespace EmpSqlTask.Data
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> employ { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<GetDepartmentwiseModel> GetEmployeesDepartmentWise {  get; set; }

        public DbSet<EmpSalary> employsalary { get; set; }
        public DbSet<GetEmply> GetEmplys { get; set; }
       
      

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetEmply>().HasNoKey();
            // ... other model configuration
        }




        /* public List<GetEmply> GetEmplys()
         {

             var results = this.employ
                .FromSqlRaw("SELECT e.empid, e.empname, d.deptname, es.salary " +
                             "FROM employ e " +
                             "INNER JOIN department d ON e.deptid = d.deptid " +
                                 "INNER JOIN employsalary es ON e.empid = es.empid").AsEnumerable()
                 .Select(e => new GetEmply
                 {
                     empid = e.empid,
                     empname = e.empname,
                     deptname = e.deptname, 
                     salary = e.salary
                 })
         .ToList<GetEmply>();


             return results;
         }*/
        // [DbFunction("GetEmployeeListSalary",Schema ="dbo")]
        // public IQueryable<GetEmply> GetEmployeeListSalary()=>throw new NotSupportedException();
    }




}



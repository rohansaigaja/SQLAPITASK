using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpSqlTask.Models
{
    
    public class Employee
    {
        internal readonly int salary;
        internal string deptname;

        [Key]
            public int empid { get; set; } 
            public string empname { get; set; }
        [ForeignKey("department")]
            public int deptid { get; set; }

       
    } 
        

    }


using System.ComponentModel.DataAnnotations;

namespace EmpSqlTask.Models
{
    public class UpdateInfoByEmp
    {
       
            [Key]
            public int empid { get; set; }
            public int salary { get; set; }
        
    }
}

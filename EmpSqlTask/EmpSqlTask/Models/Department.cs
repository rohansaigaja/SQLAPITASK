using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmpSqlTask.Models
{
    public class Department
    {

            [Key]
            public int deptid { get; set; } 
            public string deptname { get; set; }
        [ForeignKey("ManagerId")]
        //public virtual Employee? Manager { get; set; }
        public int? ManagerId { get; set; }






    }
}

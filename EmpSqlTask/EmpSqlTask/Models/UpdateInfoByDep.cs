using System.ComponentModel.DataAnnotations;

namespace EmpSqlTask.Models
{
    public class UpdateInfoByDep
    {
        [Key]
        public int deptid { get; set; }
        public int salary { get; set; }
    }
}

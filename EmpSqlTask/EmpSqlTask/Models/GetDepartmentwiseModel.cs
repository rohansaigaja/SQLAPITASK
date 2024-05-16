using System.ComponentModel.DataAnnotations;

namespace EmpSqlTask.Models
{
    public class GetDepartmentwiseModel
    {
        [Key]
        public int deptid { get; set; }
        public string? deptname { get; set; }
        public int? NumberofEmployees { get; set; }
        public decimal? SumofSalaries { get; set; }
    }
}

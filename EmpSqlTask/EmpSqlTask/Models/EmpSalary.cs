using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpSqlTask.Models
{
    public class EmpSalary
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("employ")]
        public int empid { get; set; }
         public decimal salary { get; set; }

        public DateTime effective_date { get; set; }
       


    }
}

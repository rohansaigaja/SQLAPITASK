using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmpSqlTask.Models
{
    public class DepartmentRequestModel
    {

        
        public string deptname { get; set; }
        [ForeignKey("ManagerId")]
        //public virtual Employee? Manager { get; set; }
        public int? ManagerId { get; set; }






    }
}

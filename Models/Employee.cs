using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyWeb.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }
        public String EmpName { get; set; }
        public String Job { get; set; }
        public decimal? Salary { get; set; }
        public String DName {  get; set; }
    }
}
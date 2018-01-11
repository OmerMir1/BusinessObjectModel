using System;
using System.ComponentModel.DataAnnotations;

namespace BusinnesLayerAsModel
{
    public class Employee
    {
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }

        
    }
}
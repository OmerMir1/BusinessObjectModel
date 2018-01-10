using System;
using System.ComponentModel.DataAnnotations;

namespace BusinnesLayerAsModel
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public string Gender { get; set; }
        public string City { get; set; }
        [DisplayFormat(DataFormatString = "{DD/MM/YYYY}") ]
        public DateTime DateOfBirth { get; set; }
    }
}
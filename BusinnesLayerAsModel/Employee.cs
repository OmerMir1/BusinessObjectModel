using System;

namespace BusinnesLayerAsModel
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public string Gender { get; set; }
        public string City { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
using System;
using System.Collections.Generic;

#nullable disable

namespace RESTAPI.Models
{
    public partial class Employee
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
        public int EmployeeId { get; set; }
        public float Salary { get; set; }
    }
}

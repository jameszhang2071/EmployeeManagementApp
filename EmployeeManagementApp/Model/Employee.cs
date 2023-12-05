using Android.Content.PM;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementApp.Model
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public int AddressId { get; set; }
        public string FullName { get { return FirstName + " " + LastName; }}

    }
}

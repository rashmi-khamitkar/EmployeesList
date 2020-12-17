using System;
namespace EmployeesList.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string SubDepartmentName { get; set; }
        public string DepartmentName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfileImage { get; set; }
        public string FBProfileLink { get; set; }
        public string TwitterProfileLink { get; set; }
        public bool Deleted { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}

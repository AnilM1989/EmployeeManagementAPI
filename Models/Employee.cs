namespace EmployeeManagementAPI.Models
{

    public abstract class Employee
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public string Department {get;set;}

        public string EmployeeType {get;set;}

        public int Salary {get;set;}
    }
}
using EmployeeManagementAPI.Models;

public interface IEmployeeFactory
{
    Employee CreateEmployee(string type);
}

public class EmployeeFactory : IEmployeeFactory
{
    public Employee CreateEmployee(string type) => type switch
    {
        "Manager" => new Manager(),
        "Contractor" => new Contractor(),
        "Permanent" => new Permanent(),
        "HR" => new HR(),
        "Finance" => new Finance(),
        _ => throw new ArgumentException("Invalid employee type.")
    };
}

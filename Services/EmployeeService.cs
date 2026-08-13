using JenkinsWebApi.Models;

namespace JenkinsWebApi.Services;

public class EmployeeService : IEmployeeService
{
    private static readonly List<Employee> Employees =
    [
        new Employee
        {
            Id = 1,
            Name = "Ahad",
            Department = "DevOps",
            Salary = 50000
        }
    ];

    public List<Employee> GetAll()
    {
        return Employees;
    }

    public Employee? GetById(int id)
    {
        return Employees.FirstOrDefault(e => e.Id == id);
    }

    public Employee Create(Employee employee)
    {
        employee.Id = Employees.Max(e => e.Id) + 1;

        Employees.Add(employee);

        return employee;
    }
}
using JenkinsWebApi.Models;

namespace JenkinsWebApi.Services;

public interface IEmployeeService
{
    List<Employee> GetAll();

    Employee? GetById(int id);

    Employee Create(Employee employee);
}
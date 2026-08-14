using JenkinsWebApi.Models;
using JenkinsWebApi.Services;

namespace JenkinsWebApi.Tests;

public class EmployeeServiceTests
{
    [Fact]
    public void Create_Should_Add_New_Employee()
    {
        // Arrange
        var service = new EmployeeService();

        var employee = new Employee
        {
            Name = "Ahad",
            Department = "DevOps",
            Salary = 50000m
        };

        // Act
        var result = service.Create(employee);

        // Assert
        Assert.True(result.Id > 0);
        Assert.Equal("Ahad", result.Name);
    }
}
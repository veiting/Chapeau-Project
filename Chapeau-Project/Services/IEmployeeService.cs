using Chapeau_Project.Models;

namespace Chapeau_Project.Services
{
    public interface IEmployeeService
    {
        Employee? GetByLoginCredentials(string employeeId, string password);
    }
}
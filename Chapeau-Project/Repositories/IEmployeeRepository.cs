using Chapeau_Project.Models;

namespace Chapeau_Project.Repositories
{
    public interface IEmployeeRepository
    {
        public Employee? GetByLoginCredentials(string employeeNumber, string password);

    }
}

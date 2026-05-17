using System.Security.Cryptography;
using System.Text;
using Chapeau_Project.Models;
using Chapeau_Project.Repositories;

namespace Chapeau_Project.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee? GetByLoginCredentials(string employeeId, string password)
        {
            return _employeeRepository.GetByLoginCredentials(employeeId, HashPassword(password));
        }
    

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
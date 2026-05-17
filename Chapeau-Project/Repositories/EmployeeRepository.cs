using Chapeau_Project.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Chapeau_Project.Repositories

{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string? _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Chapeau-Project");
        }

        public Employee? GetByLoginCredentials(string employeeNumber, string password)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT EmployeeId, FirstName, LastName, EmployeeNumber, Password, Role, IsActive " +
                               "FROM Employee WHERE EmployeeNumber = @EmployeeNumber AND Password = @Password AND IsActive = 1";
                
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Employee
                            {
                                EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                EmployeeNumber = Convert.ToInt32(reader["EmployeeNumber"]),
                                Password = reader["Password"].ToString(),
                                Role = (EmployeeRole)Enum.Parse(typeof(EmployeeRole), reader["Role"].ToString()),
                                IsActive = (bool)reader["IsActive"]
                            };
                        }
                        return null;
                    }


                }
            }
        }
    }
}

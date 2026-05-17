using Microsoft.Data.SqlClient;
using Chapeau_Project.Models;
using Chapeau_Project.Repositories;
using Microsoft.Extensions.Configuration;

namespace Chapeau_Project.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly string _connectionString;

        public TableRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Chapeau-Project");
        }

        public List<Table> GetAll()
        {
            List<Table> tables = new List<Table>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT TableId, TableNumber, Capacity, Status, EmployeeId FROM [Table]";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tables.Add(new Table
                            {
                                TableId = (int)reader["TableId"],
                                TableNumber = (int)reader["TableNumber"],
                                Capacity = (int)reader["Capacity"],
                                Status = reader["Status"].ToString(),
                                EmployeeId = reader["EmployeeId"] as int?
                            });
                        }
                    }
                }
            }
            return tables;
        }

        // Not needed for Sprint 1
        public Table? GetById(int tableId) => null;
        public void Update(Table table) { }
    }
}
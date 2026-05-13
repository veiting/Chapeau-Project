using Chapeau_Project.Models;
using Microsoft.Data.SqlClient;

namespace Chapeau_Project.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly string _connectionString;

    public MenuItemRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Chapeau-Project");
    }

    public List<MenuItem> GetAll()
    {
        List<MenuItem> menuItems = new List<MenuItem>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM MenuItems";
        }
    }
}
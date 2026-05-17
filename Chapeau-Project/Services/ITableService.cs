using Chapeau_Project.Models;

namespace Chapeau_Project.Services
{
    public interface ITableService
    {
        List<Table> GetAll();
        Table? GetById(int tableId);
        void Update(Table table);
    }
}

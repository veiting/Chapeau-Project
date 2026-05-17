using Chapeau_Project.Models;

namespace Chapeau_Project.Repositories
{
    public interface ITableRepository
    {
        List<Table> GetAll();
        Table? GetById(int tableId);
        void Update(Table table);
    }
}
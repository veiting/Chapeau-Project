using Chapeau_Project.Models;
using Chapeau_Project.Repositories;

namespace Chapeau_Project.Services
{
    public class TableService : ITableService
    {
        private ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public List<Table> GetAll()
        {
            return _tableRepository.GetAll();
        }

        public Table? GetById(int tableId)
        {
            return _tableRepository.GetById(tableId);
        }

        public void Update(Table table)
        {
            _tableRepository.Update(table);
        }
    }
}

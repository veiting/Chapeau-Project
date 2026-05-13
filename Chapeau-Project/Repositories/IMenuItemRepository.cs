using Chapeau_Project.Models;

namespace Chapeau_Project.Repositories;

public interface IMenuItemRepository
{
    List<MenuItem> GetAll();
    MenuItem? GetById(int id);
    void Add(MenuItem item);
    void Update(MenuItem item);
    void deactivate(int id);
    
}
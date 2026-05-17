
using Chapeau_Project.Models;

namespace Chapeau_Project.ViewModels
{
    public class TableOverviewViewModel
    {
        public List<Table> Tables { get; set; }
        public Employee? LoggedInEmployee { get; set; }
        

    }
}
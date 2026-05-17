using Microsoft.AspNetCore.Mvc;
using Chapeau_Project.Models;
using Chapeau_Project.Services;
using Chapeau_Project.ViewModels;

namespace Chapeau_Project.Controllers
{
    public class TableController : Controller
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        public ActionResult Overview()
        {
            Employee? loggedInEmployee = HttpContext.Session.GetObject<Employee>("LoggedInEmployee");
            ViewData["LoggedInEmployee"] = loggedInEmployee;

            List<Table> tables = _tableService.GetAll();
            TableOverviewViewModel viewModel = new TableOverviewViewModel
            {
                Tables = tables,
                LoggedInEmployee = loggedInEmployee
            };

            return View(viewModel);
        }
    }
}
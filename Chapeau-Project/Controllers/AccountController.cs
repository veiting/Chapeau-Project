using Microsoft.AspNetCore.Mvc;
using Chapeau_Project.Models;
using Chapeau_Project.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Chapeau_Project.Repositories;
using Chapeau_Project.ViewModels;

namespace Chapeau_Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public AccountController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        private void SignInEmployee(Employee employee)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, employee.EmployeeId.ToString()),
                new Claim(ClaimTypes.Name, employee.FirstName),
                new Claim(ClaimTypes.Role, employee.Role.ToString())
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, 
                CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(principal);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            Employee? employee = _employeeService.GetByLoginCredentials(
                                loginModel.EmployeeId, loginModel.Password);

            if (employee == null)
            {
                ViewBag.ErrorMessage = "Invalid Employee ID or Password.";
                return View(loginModel);
            }
            else
            {
                SignInEmployee(employee);
                HttpContext.Session.SetObject("LoggedInEmployee", employee);
                return RedirectToAction("Overview", "Table");
            }
        }

        public IActionResult Logoff()
        {
            HttpContext.SignOutAsync();
            Response.Cookies.Delete("EmployeeId");
            return RedirectToAction("Login", "Account");
        }
    }
}
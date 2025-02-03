using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Social.Application.Services.Interface;
using Social.Domain.Entities;
using Social.Infrastructure.Data;

namespace Social.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees().ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.CreateEmployee(employee);
                TempData["success"] = "The employee has been created successfully.";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Update(int employeeId)
        {
            Employee? obj = _employeeService.GetEmployeeById(employeeId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult Update(Employee obj)
        {
            if (ModelState.IsValid && obj.EmployeeId > 0)
            {
                _employeeService.UpdateEmployee(obj);
                TempData["success"] = "The Employee has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int employeeId)
        {
            Employee? obj = _employeeService.GetEmployeeById(employeeId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }


        [HttpPost]
        public IActionResult Delete(Employee obj)
        {
            Employee? employee = _employeeService.GetEmployeeById(obj.EmployeeId);
            if (employee is not null)
            {
                _employeeService.DeleteEmployee(obj.EmployeeId);
                TempData["success"] = "The Employee has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Failed to delete the Employee.";
            }
            return View();
        }
    }
}

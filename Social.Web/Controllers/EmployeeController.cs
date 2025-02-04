using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Social.Application.Services.Interface;
using Social.Domain.Entities;
using Social.Infrastructure.Data;
using Social.Web.ViewModels;

namespace Social.Web.Controllers
{
    //[Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ITalukService _talukService;

        public EmployeeController(IEmployeeService employeeService, ITalukService talukService)
        {
            _employeeService = employeeService;
            _talukService = talukService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployees().ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            EmployeeVM employeeVM = new()
            {
                TalukList = _talukService.GetAllTaluks().Select(u => new SelectListItem
                {
                    Text = u.TalukName,
                    Value = u.TalukId.ToString()
                })
            };
            return View(employeeVM);
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM employeeVm)
        {
            if (ModelState.IsValid)
            {
                _employeeService.CreateEmployee(employeeVm.Employee);
                TempData["success"] = "The employee has been created successfully.";
                return RedirectToAction("Index");
            }
            employeeVm.TalukList = _talukService.GetAllTaluks().Select(u => new SelectListItem
            {
                Text = u.TalukName,
                Value = u.TalukId.ToString()
            });
            return View(employeeVm);

        }
        public IActionResult Update(int employeeId)
        {
            EmployeeVM employeeVM = new()
            {
                TalukList = _talukService.GetAllTaluks().Select(u => new SelectListItem
                {
                    Text = u.TalukName,
                    Value = u.TalukId.ToString()
                }),
                Employee = _employeeService.GetEmployeeById(employeeId)
            };
            if (employeeVM.Employee == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(employeeVM);
        }

        [HttpPost]
        public IActionResult Update(EmployeeVM employeeVm)
        {
            if (ModelState.IsValid && employeeVm.Employee.EmployeeId > 0)
            {
                _employeeService.UpdateEmployee(employeeVm.Employee);
                TempData["success"] = "The Employee has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            employeeVm.TalukList = _talukService.GetAllTaluks().Select(u => new SelectListItem
            {
                Text = u.TalukName,
                Value = u.TalukId.ToString()
            });
            return View(employeeVm);
        }

        public IActionResult Delete(int employeeId)
        {

            EmployeeVM employeeVM = new()
            {
                TalukList = _talukService.GetAllTaluks().Select(u => new SelectListItem
                {
                    Text = u.TalukName,
                    Value = u.TalukId.ToString()
                }),
                Employee = _employeeService.GetEmployeeById(employeeId)
            };
            if (employeeVM.Employee == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(employeeVM);
        }


        [HttpPost]
        public IActionResult Delete(EmployeeVM employeeVm)
        {
            Employee? employee = _employeeService.GetEmployeeById(employeeVm.Employee.EmployeeId);
            if (employee is not null)
            {
                _employeeService.DeleteEmployee(employee.EmployeeId);
                TempData["success"] = "The Employee has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "Failed to delete the Employee.";
            return View();
        }
    }
}

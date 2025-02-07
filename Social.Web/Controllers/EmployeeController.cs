using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Social.Application.Common.Utility;
using Social.Application.Services.Interface;
using Social.Domain.Entities;
using Social.Infrastructure.Data;
using Social.Web.ViewModels;

namespace Social.Web.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeSkillService _employeeSkillService;
        private readonly ITalukService _talukService;
        private readonly ISkillService _skillService;

        public EmployeeController(IEmployeeService employeeService, ITalukService talukService, ISkillService skillService, IEmployeeSkillService employeeSkillService)
        {
            _employeeService = employeeService;
            _talukService = talukService;
            _skillService = skillService;
            _employeeSkillService = employeeSkillService;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetEmployeesByUser(User.Identity.Name).ToList();
            return View(employees);
        }

        [Authorize(Policy = SD.Policy_AdminOrDistrictOffier)]
        public IActionResult MasterIndex()
        {
            var employees = _employeeService.GetAllEmployees().ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            EmployeeVM employeeVM = new()
            {
                TalukList = GetTalukList(),
                SkillList = GetSkillList()
            };
            return View(employeeVM);
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM employeeVm)
        {
            if (ModelState.IsValid)
            {
                employeeVm.Employee.CreatedBy = User.Identity.Name;
                employeeVm.Employee.CreatedAt = DateTime.Now;
                employeeVm.Employee.ModifiedBy = User.Identity.Name;
                employeeVm.Employee.ModifiedAt = DateTime.Now;
                _employeeService.CreateEmployee(employeeVm.Employee);
                UpdateEmployeeSkills(employeeVm);

                TempData["success"] = "The employee has been created successfully.";
                return RedirectToAction("Index");
            }
            employeeVm.TalukList = GetTalukList();
            employeeVm.SkillList = GetSkillList();
            return View(employeeVm);

        }
        public IActionResult Update(int employeeId)
        {
            var emp = _employeeService.GetEmployeeById(employeeId);
            EmployeeVM employeeVM = new()
            {
                TalukList = GetTalukList(),
                SkillList = GetSkillList(),
                Employee = emp,
                SelectedSkills = emp.EmployeeSkills.Select(x => x.SkillId).ToList()
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
                employeeVm.Employee.ModifiedBy = User.Identity.Name;
                employeeVm.Employee.ModifiedAt = DateTime.Now;
                _employeeService.UpdateEmployee(employeeVm.Employee);

                _employeeSkillService.DeleteEmployeeSkills(employeeVm.Employee.EmployeeId);
                UpdateEmployeeSkills(employeeVm);

                TempData["success"] = "The Employee has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }

            employeeVm.TalukList = GetTalukList();
            employeeVm.SkillList = GetSkillList();
            return View(employeeVm);
        }

        public IActionResult Delete(int employeeId)
        {
            var emp = _employeeService.GetEmployeeById(employeeId);
            EmployeeVM employeeVM = new()
            {
                TalukList = GetTalukList(),
                SkillList = GetSkillList(),
                Employee = emp,
                SelectedSkills = emp.EmployeeSkills.Select(x=>x.SkillId).ToList()
            };
            if (employeeVM.Employee == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(employeeVM);
        }

        public IActionResult Details(int employeeId)
        {
            var emp = _employeeService.GetEmployeeById(employeeId);
            EmployeeVM employeeVM = new()
            {
                TalukList = GetTalukList(),
                SkillList = GetSkillList(),
                Employee = emp,
                SelectedSkills = emp.EmployeeSkills.Select(x => x.SkillId).ToList()
            };
            if (employeeVM.Employee == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(employeeVM);
        }

        [Authorize(Policy = SD.Policy_AdminOrDistrictOffier)]
        public IActionResult MasterDetails(int employeeId)
        {
            var emp = _employeeService.GetEmployeeById(employeeId);
            EmployeeVM employeeVM = new()
            {
                TalukList = GetTalukList(),
                SkillList = GetSkillList(),
                Employee = emp,
                SelectedSkills = emp.EmployeeSkills.Select(x => x.SkillId).ToList()
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

        private IEnumerable<SelectListItem> GetTalukList()
        {
            return _talukService.GetAllTaluks().Select(u => new SelectListItem
            {
                Text = u.TalukName,
                Value = u.TalukId.ToString()
            });
        }
        private IEnumerable<SelectListItem> GetSkillList()
        {
            return _skillService.GetAllSkills().Select(u => new SelectListItem
            {
                Text = u.SkillName,
                Value = u.SkillId.ToString()
            });
        }

        private void UpdateEmployeeSkills(EmployeeVM employeeVm)
        {
            if (employeeVm.SelectedSkills != null)
            {
                foreach (var skillId in employeeVm.SelectedSkills)
                {
                    var empSkill = new EmployeeSkill
                    {
                        EmployeeId = employeeVm.Employee.EmployeeId,
                        SkillId = skillId
                    };
                    _employeeSkillService.CreateEmployeeSkill(empSkill);
                }
            }
        }
    }

}

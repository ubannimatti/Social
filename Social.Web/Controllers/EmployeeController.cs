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
            var empFilterVm = new EmployeeFilterVM();
            return View(empFilterVm);
        }

        [Authorize(Policy = SD.Policy_AdminOrDistrictOffier)]
        [HttpPost]
        public IActionResult MasterIndex(EmployeeFilterVM empFilter)
        {
            var employees = _employeeService.GetAllEmployees();

            if(empFilter.HasOwnHouse != null)
            {
                employees = employees.Where(x => x.HasAHouse.Equals(empFilter.HasOwnHouse));
            }
            if (empFilter.HasSite != null)
            {
                employees = employees.Where(x => x.HasASite.Equals(empFilter.HasSite));
            }
            if (empFilter.HasToilet != null)
            {
                employees = employees.Where(x => x.HasAToilet.Equals(empFilter.HasToilet));
            }
            if (empFilter.HasElectricity != null)
            {
                employees = employees.Where(x => x.HasElectricityConnection.Equals(empFilter.HasElectricity));
            }
            if (empFilter.HasWaterConnection != null)
            {
                employees = employees.Where(x => x.HasWaterConnection.Equals(empFilter.HasWaterConnection));
            }
            if (empFilter.HasSite != null)
            {
                employees = employees.Where(x => x.HasAHouse.Equals(empFilter.HasSite));
            }
            if (empFilter.HasAadharCard != null)
            {
                employees = employees.Where(x => x.HasAadharCard.Equals(empFilter.HasAadharCard));
            }
            if (empFilter.HasAayushmannBharatCard != null)
            {
                employees = employees.Where(x => x.HasAyushmanBharatCard.Equals(empFilter.HasAayushmannBharatCard));
            }
            if (empFilter.HasHealthInsurance != null)
            {
                employees = employees.Where(x => x.HasHealthInsurance.Equals(empFilter.HasHealthInsurance));
            }
            if (empFilter.HasRationCard != null)
            {
                employees = employees.Where(x => x.HasRationCard.Equals(empFilter.HasRationCard));
            }
            if (empFilter.HasNaregaJobCard != null)
            {
                employees = employees.Where(x => x.HasNaregaJobCard.Equals(empFilter.HasNaregaJobCard));
            }

            empFilter.Employees = employees.ToList();
            return View(empFilter);
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

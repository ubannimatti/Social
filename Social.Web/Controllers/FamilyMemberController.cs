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
    public class FamilyMemberController : Controller
    {
        private readonly IFamilyMemberService _familyMemberService;
        private readonly IEmployeeService _employeeService;

        public FamilyMemberController(IFamilyMemberService familyMemberService, IEmployeeService employeeService)
        {
            _familyMemberService = familyMemberService;
            _employeeService = employeeService;
        }

        public IActionResult Index(int employeeId)
        {
            var familyMembersList = new FamilyMemberListVM();
            List<FamilyMember> familyMembers = new List<FamilyMember>();
            if (employeeId != 0)
            {
                familyMembersList.EmployeeId = employeeId;
                familyMembersList.EmployeeName = _employeeService.GetEmployeeById(employeeId).EmployeeName;
                familyMembers = _familyMemberService.GetFamilyMembers(employeeId).ToList();
            }

            familyMembersList.FamilyMembers = familyMembers;
            return View(familyMembersList);

        }

        public IActionResult Create(int employeeId)
        {
            FamilyMemberVM familyMemberVM = new()
            {
                FamilyMember = new FamilyMember { EmployeeId = employeeId, FamilyMemberName = "" },
                EmployeeList = GetEmployees()
            };
            return View(familyMemberVM);
        }

        [HttpPost]
        public IActionResult Create(FamilyMemberVM familyMemberVm)
        {
            if (ModelState.IsValid)
            {
                familyMemberVm.FamilyMember.CreatedBy = User.Identity.Name;
                familyMemberVm.FamilyMember.CreatedAt = DateTime.Now;
                familyMemberVm.FamilyMember.ModifiedBy = User.Identity.Name;
                familyMemberVm.FamilyMember.ModifiedAt = DateTime.Now;
                _familyMemberService.CreateFamilyMember(familyMemberVm.FamilyMember);
                TempData["success"] = "The Family Member has been created successfully.";
                return RedirectToAction("Index",new {employeeId = familyMemberVm.FamilyMember.EmployeeId});
            }
            familyMemberVm.EmployeeList = GetEmployees();
            return View(familyMemberVm);

        }
        public IActionResult Update(int familyMemberId)
        {
            FamilyMemberVM familyMemberVM = new()
            {
                EmployeeList = GetEmployees(),
                FamilyMember = _familyMemberService.GetFamilyMemberById(familyMemberId)
            };
            if (familyMemberVM.FamilyMember == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(familyMemberVM);
        }

        [HttpPost]
        public IActionResult Update(FamilyMemberVM familyMemberVm)
        {
            if (ModelState.IsValid && familyMemberVm.FamilyMember.FamilyMemberId > 0)
            {
                familyMemberVm.FamilyMember.ModifiedBy = User.Identity.Name;
                familyMemberVm.FamilyMember.ModifiedAt = DateTime.Now;
                _familyMemberService.UpdateFamilyMember(familyMemberVm.FamilyMember);
                TempData["success"] = "The Family Member has been updated successfully.";
                return RedirectToAction("Index", new { employeeId = familyMemberVm.FamilyMember.EmployeeId });
            }
            familyMemberVm.EmployeeList = GetEmployees();
            return View(familyMemberVm);
        }

        public IActionResult Delete(int familyMemberId)
        {

            FamilyMemberVM familyMemberVM = new()
            {
                EmployeeList = GetEmployees(),
                FamilyMember = _familyMemberService.GetFamilyMemberById(familyMemberId)
            };
            if (familyMemberVM.FamilyMember == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(familyMemberVM);
        }


        [HttpPost]
        public IActionResult Delete(FamilyMemberVM familyMemberVm)
        {
            FamilyMember? familyMember = _familyMemberService.GetFamilyMemberById(familyMemberVm.FamilyMember.FamilyMemberId);
            if (familyMember is not null)
            {
                var employeeId = familyMemberVm.FamilyMember.EmployeeId;
                _familyMemberService.DeleteFamilyMember(familyMember.FamilyMemberId);
                TempData["success"] = "The Family Member has been deleted successfully.";
                return RedirectToAction("Index", new { employeeId = employeeId });
            }
            TempData["error"] = "Failed to delete the Family Member.";
            return View();
        }

        private IEnumerable<SelectListItem> GetEmployees()
        {
            return _employeeService.GetAllEmployees().Select(u => new SelectListItem
            {
                Text = u.EmployeeName,
                Value = u.EmployeeId.ToString()
            });
        }
    }
}

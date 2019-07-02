using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsTogether.BLL.Interfaces;
using LetsTogether.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LetsTogether.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;
        private readonly SignInManager<User> AuthenticationManager;

        public AdminController(
            SignInManager<User> authenticationManager,
            IAdminService _adminService
            )
        {
            AuthenticationManager = authenticationManager;
            adminService = _adminService;

        }

        public IActionResult Main()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View(adminService.Users());
        }

        public IActionResult Categories()
        {
            return View(adminService.Categories());
        }

        [HttpPost]
        public IActionResult AddCategory(string title)
        {
            adminService.AddCategory(title);
            return RedirectToAction("Categories", "Admin");
        }
    }
}
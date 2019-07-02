using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsTogether.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LetsTogether.BLL.Services;
using Microsoft.AspNetCore.Identity;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.EF;
using LetsTogether.DAL.Repositories;
using LetsTogether.Web.Models;
using LetsTogether.BLL.DTO;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.Owin.Host.SystemWeb;
using LetsTogether.BLL.Infrastructure;
using System.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace LetsTogether.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService userService;
        private readonly SignInManager<User> AuthenticationManager;
        private readonly IMapper mapper;

        public AccountController(
            SignInManager<User> authenticationManager,
            IUserService _userService,
            IMapper _mapper
            )
        {
            AuthenticationManager = authenticationManager;
            userService = _userService;
            mapper = _mapper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {                
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                bool auth = await userService.Authenticate(userDto);
                if (!auth)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {     
                  return RedirectToAction("Profile", "Profile");
                }
            }
            return View(model);
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = mapper.Map<RegisterModel, UserDTO>(model);  
                OperationDetails operationDetails = await userService.Create(userDto);
                if (operationDetails.Succedeed)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }

        private async Task SetInitialDataAsync()
        {
            await userService.SetInitialData(new List<string> { "user", "admin" });
            UserDTO userDto = new UserDTO
            {
                Email = "tania@gmail.com",
                UserName = "tetiana",
                Password = "Tetianka-09",
                Role = "admin",
                Birthday = new DateTime(1999, 09, 24),
                Gender = "Female",
                Location = new Location() { Country = "Country", City = "Chernivtsi" },
                Phone = "0963853151"
            };
            await userService.Create(userDto);
        }

        public async Task<IActionResult> Logout()
        {                                    
            await AuthenticationManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

       

    }
}
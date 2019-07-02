using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LetsTogether.BLL.DTO;
using LetsTogether.BLL.Infrastructure;
using LetsTogether.BLL.Interfaces;
using LetsTogether.BLL.Services;
using LetsTogether.DAL.Entities;
using LetsTogether.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LetsTogether.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;
        private readonly SignInManager<User> AuthenticationManager;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public ProfileController(
            SignInManager<User> authenticationManager,
            IProfileService _profileService,
            IHostingEnvironment appEnvironment,
            ICategoryService _categoryService,
            IMapper _mapper
            )
        {
            AuthenticationManager = authenticationManager;
            profileService = _profileService;
            _appEnvironment = appEnvironment;
            categoryService = _categoryService;
            mapper = _mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddPhoto(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/images/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                User user = await profileService.Find(User.Identity.Name);
                ProfileDTO profile = new ProfileDTO() { GetUser = user };
                await profileService.AddPhoto(path, profile.GetUser.Profile);
                return RedirectToAction("Profile");
            }
            return RedirectToAction("Index", "Home");
            
        }

        public async Task<IActionResult> Edit(string id)
        {
            User user = await profileService.FindById(id);
            if (user == null)
                return NotFound();           
            return View(mapper.Map<User, EditProfileModel>(user));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProfileModel model)
        {
            await profileService.Edit(mapper.Map<EditProfileModel, EditProfileDTO>(model));
            return RedirectToAction("Profile", "Profile");
        }

        public IActionResult ChooseCategories(string id)
        {
            List<string> selected_categories = new List<string>();
            foreach (var item in categoryService.UserCategories(id))
            {
                selected_categories.Add(item.Name);
            }
            ChooseCategoryModel chooseCategoryModel = new ChooseCategoryModel
            {
                SelectedCategories = selected_categories,
                Categories = categoryService.Categories()
            };
            return View(chooseCategoryModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChooseCategories(ChooseCategoryModel model)
        {
            ProfileDTO p = await profileService.FindProfileByUserName(User.Identity.Name);
            UserCategoryDTO userCategoryDTO = new UserCategoryDTO
            {
                Categories = model.SelectedCategories,
                Id = p.GetUser.Id
            };
            OperationDetails result = await categoryService.AddUserCategories(userCategoryDTO);

            return RedirectToAction("Profile", "Profile");
        }
    

    [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {

            await profileService.Delete(id);
            return RedirectToAction("Profile", "Profile");

        }


        public async Task<ActionResult> Profile()
        {
            User user = await profileService.Find(User.Identity.Name);
            ProfileDTO profile = new ProfileDTO { GetUser = user };
            return View(profile);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
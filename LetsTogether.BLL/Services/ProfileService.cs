using LetsTogether.BLL.DTO;
using LetsTogether.BLL.Infrastructure;
using LetsTogether.BLL.Interfaces;
using LetsTogether.BLL.Interfaces;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity;

namespace LetsTogether.BLL.Services
{
    public class ProfileService : IProfileService
    {
        IUnitOfWork Database { get; set; }

        public ProfileService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<User> Find(string UserName)
        {
            User user = await Database.UserManager.FindByNameAsync(UserName);
            user.Profile = Database.ProfileManager.FindById(user.Id);
            user.Profile.Avatar = Database.PhotoRepository.GetById(user.Profile.PhotoId);
            return user;
        }

        public async Task AddPhoto(string url, Profile profile)
        {
            Photo photo = Database.PhotoRepository.Add(new Photo { Url = url });
            profile.Avatar = photo;
            await Database.SaveAsync();
        }

        public async Task<ProfileDTO> FindProfileByUserName(string UserName)
        {
            User user = Database.ProfileManager.FindByUserName(UserName);
            ProfileDTO profile = new ProfileDTO()
            {
                GetUser = user
            };
            return profile;
        }


        public async Task<User> FindById(string id)
        {
            Profile profile = Database.ProfileManager.FindById(id);
            profile.Location = Database.LocationRepository.GetById(profile.LocationId);
            User user = await Database.UserManager.FindByIdAsync(profile.Id);
            return user;
        }


        public async Task<OperationDetails> Edit(EditProfileDTO model)
        {
            Profile profile = Database.ProfileManager.FindById(model.Id);
            User user = await Database.UserManager.FindByIdAsync(model.Id);
            if (model.UserName != null)
            {
                User clone = await Database.UserManager.FindByEmailAsync(model.UserName);
                if (model.UserName != user.UserName && clone != null)
                    return new OperationDetails(false, "Username is being use", "");
                user.UserName = model.UserName;

            }
            if (model.Location != null)
            {
                if (Database.LocationRepository.FindClone(model.Location) == null)
                {
                    Location l = Database.LocationRepository.Add(model.Location);
                    profile.Location = l;
                }
            }
            if (model.Birthday != null)
            {
                profile.Birthday = model.Birthday;
            }
            await Database.SaveAsync();
            return new OperationDetails(true, "Ok", "");
        }

        public async Task Delete(string id)
        {
            User user = await Database.UserManager.FindByIdAsync(id);
            foreach (var item in Database.UserCategoryRepository.FindById(id))
            {
                Database.UserCategoryRepository.Delete(item);
            }
            if (user != null)
            {
                IdentityResult result = await Database.UserManager.DeleteAsync(user);
            }

        }

        public List<Category> Categories(string id)
        {
            return Database.CategoryRepository.Categories(id);
        }



        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

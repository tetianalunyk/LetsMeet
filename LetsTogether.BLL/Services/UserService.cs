using LetsTogether.BLL.DTO;
using LetsTogether.BLL.Infrastructure;
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

namespace LetsTogether.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            User user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new User { Email = userDto.Email, UserName = userDto.UserName, PhoneNumber = userDto.Phone };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");
                // добавляем роль
                await Database.UserManager.AddToRoleAsync(user, userDto.Role);
                // создаем профиль клиента
                Location location = Database.LocationRepository.FindClone(userDto.Location);   
                if(location == null)
                {
                    location = userDto.Location;
                    Database.LocationRepository.Add(userDto.Location);
                }
                Profile clientProfile = new Profile {
                    Id = user.Id,
                    Birthday = userDto.Birthday,
                    Gender = userDto.Gender,
                    Location = location,
                    Avatar = Database.PhotoRepository.GetById(1)
                };
                Database.ProfileManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<bool> Authenticate(UserDTO userDto)
        {
            // находим пользователя    

            var user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = await Database.UserManager.FindByNameAsync(userDto.Email);
                if (user == null)
                {
                    return false;
                }
            }
            var username = user.UserName;
            var auth = await Database.SignInManager.PasswordSignInAsync(username, userDto.Password, false, lockoutOnFailure: false);
            // авторизуем его 
            return auth.Succeeded;
        }

        // начальная инициализация бд
        public async Task SetInitialData(List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new IdentityRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
        }

            public void Dispose()
        {
            Database.Dispose();
        }
        
    }
}

using LetsTogether.BLL.Infrastructure;
using LetsTogether.BLL.Interfaces;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsTogether.BLL.Services
{
    public class AdminService: IAdminService
    {
        private readonly IUnitOfWork Database;


        public AdminService(IUnitOfWork db)
        {
            Database = db;
        }

        public List<User> Users()
        {
            return Database.UserManager.Users.ToList();
        }

        public List<Category> Categories()
        {
            return Database.CategoryRepository.GetAll().ToList();
        }

        public OperationDetails AddCategory(string title)
        {
            Category temp = new Category() { Name = title };
            Database.CategoryRepository.Add(temp);
            Database.SaveAsync();
            return new OperationDetails(true, "Ok", "");
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

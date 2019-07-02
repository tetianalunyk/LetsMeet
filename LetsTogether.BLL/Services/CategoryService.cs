using LetsTogether.BLL.DTO;
using LetsTogether.BLL.Infrastructure;
using LetsTogether.BLL.Interfaces;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsTogether.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork Database;
        public CategoryService(IUnitOfWork db)
        {
            Database = db;
        }

        public async Task<OperationDetails> AddUserCategories(UserCategoryDTO model)
        {
            foreach (var item in Database.UserCategoryRepository.FindById(model.Id))
            {
                Database.UserCategoryRepository.Delete(item);
            }
            foreach (var item in model.Categories)
            {
                Database.UserCategoryRepository.Add(new UserCategory
                {
                    Category = Database.CategoryRepository.GetByTitle(item),
                    User = await Database.UserManager.FindByIdAsync(model.Id)
                });
                await Database.SaveAsync();
            }
            return new OperationDetails(true, "Ok", "");
        }

        public List<Category> UserCategories(string id)
        {
            return Database.CategoryRepository.Categories(id);
        }

        public List<Category> Categories()
        {
            return Database.CategoryRepository.GetAll().ToList();
        }

        public OperationDetails AddCategory(string title)
        {
            Database.CategoryRepository.Add(new Category() { Name = title });
            Database.SaveAsync();
            return new OperationDetails(true, "Ok", "");
        }

        public OperationDetails DeleteCategory(int id)
        {
            Database.CategoryRepository.Delete(Database.CategoryRepository.GetById(id));
            Database.SaveAsync();
            return new OperationDetails(true, "Ok", "");
        }



        public void Dispose()
        {
            Database.Dispose();
        }


    }
}
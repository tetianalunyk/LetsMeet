
using LetsTogether.DAL.EF;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsTogether.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDBContext db) : base(db)
        {

        }

        public List<Category> Categories(string id)
        {
            List<Category> categories = new List<Category>();
            foreach (var item in Database.UserCategories.Where(x => x.UserId == id))
            {
                categories.Add(Database.Categories.FirstOrDefault(x => x.Id == item.CategoryId));
            }
            return categories;
        }

        public Category GetByTitle(string title)
        {
            return Database.Categories.FirstOrDefault(x => x.Name == title);
        }
    }
}
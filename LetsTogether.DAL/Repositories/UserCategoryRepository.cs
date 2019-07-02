using LetsTogether.DAL.EF;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsTogether.DAL.Repositories
{
    public class UserCategoryRepository : Repository<UserCategory>, IUserCategoryRepository
    {
        public UserCategoryRepository(AppDBContext context) : base(context)
        {
        }
        public List<UserCategory> FindById(string id)
        {
            return Database.UserCategories.Where(x => x.UserId == id).ToList();
        }
    }
}

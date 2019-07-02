using LetsTogether.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsTogether.DAL.Interfaces
{
    public interface IUserCategoryRepository : IRepository<UserCategory>
    {
        List<UserCategory> FindById(string id);
    }
}

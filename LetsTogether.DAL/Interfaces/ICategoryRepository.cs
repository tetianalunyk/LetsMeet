using LetsTogether.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace LetsTogether.DAL.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> Categories(string id);
        Category GetByTitle(string title);
    }
}

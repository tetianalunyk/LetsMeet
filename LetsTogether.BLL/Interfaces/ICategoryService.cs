using LetsTogether.BLL.DTO;
using LetsTogether.BLL.Infrastructure;
using LetsTogether.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetsTogether.BLL.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        List<Category> Categories();
        List<Category> UserCategories(string id);
        Task<OperationDetails> AddUserCategories(UserCategoryDTO model);
        OperationDetails AddCategory(string title);
        OperationDetails DeleteCategory(int id);
    }
}

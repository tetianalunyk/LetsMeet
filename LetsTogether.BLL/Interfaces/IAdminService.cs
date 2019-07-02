using LetsTogether.BLL.Infrastructure;
using LetsTogether.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsTogether.BLL.Interfaces
{
    public interface IAdminService : IDisposable
    {
        List<User> Users();
        List<Category> Categories();
        OperationDetails AddCategory(string title);
    }
}

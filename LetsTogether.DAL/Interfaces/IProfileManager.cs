using LetsTogether.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsTogether.DAL.Interfaces
{
    public interface IProfileManager : IDisposable
    {
        void Create(Profile profile);
        Profile FindById(string id);
        User FindByUserName(string UserName);
    }
}

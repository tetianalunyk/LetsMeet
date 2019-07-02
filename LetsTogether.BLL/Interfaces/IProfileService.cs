using LetsTogether.BLL.DTO;
using LetsTogether.BLL.Infrastructure;
using LetsTogether.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetsTogether.BLL.Interfaces
{
    public interface IProfileService : IDisposable
    {
        Task<User> Find(string UserName);
        Task AddPhoto(string url, Profile profile);
        Task<OperationDetails> Edit(EditProfileDTO model);
        Task<User> FindById(string id);
        Task Delete(string id);
        Task<ProfileDTO> FindProfileByUserName(string UserName);

    }
}

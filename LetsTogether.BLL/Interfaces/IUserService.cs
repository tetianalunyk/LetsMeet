using LetsTogether.BLL.DTO;
using LetsTogether.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LetsTogether.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<bool> Authenticate(UserDTO userDto);
        Task SetInitialData(List<string> roles);
    }
}

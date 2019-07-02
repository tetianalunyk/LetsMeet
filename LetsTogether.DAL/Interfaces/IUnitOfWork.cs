using LetsTogether.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetsTogether.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        UserManager<User> UserManager { get; }
        IProfileManager ProfileManager { get; }
        SignInManager<User> SignInManager { get; }
        RoleManager<IdentityRole> RoleManager { get; }
        ILocationRepository LocationRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IUserCategoryRepository UserCategoryRepository { get; }
        IEventCategoryRepository EventCategoryRepository { get; }
        IEventPhotoRepository EventPhotoRepository { get; }
        IEventRepository EventRepository { get; }
        IEventVisitorsRepository EventVisitorsRepository { get; }
        Task SaveAsync();
    }
}

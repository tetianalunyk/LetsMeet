using LetsTogether.DAL.EF;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetsTogether.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        public AppDBContext Database { get; private set; }
        public UserManager<User> UserManager { get; private set; }
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public IProfileManager ProfileManager { get; private set; }
        public SignInManager<User> SignInManager { get; private set; }
        public ILocationRepository LocationRepository { get; private set; }
        public IPhotoRepository PhotoRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public IUserCategoryRepository UserCategoryRepository { get; private set; }
        public IEventCategoryRepository EventCategoryRepository { get; private set; }
        public IEventPhotoRepository EventPhotoRepository { get; private set; }
        public IEventVisitorsRepository EventVisitorsRepository { get; private set; }
        public IEventRepository EventRepository { get; private set; }

        public IdentityUnitOfWork(ILocationRepository _locationRepository,
                                  IProfileManager _profileManager,
                                  AppDBContext db,
                                  SignInManager<User> signInManager,
                                  UserManager<User> userManager,
                                  RoleManager<IdentityRole> roleManager,
                                  IPhotoRepository _photoRepository,
                                  ICategoryRepository _categoriesRepository,
                                  IUserCategoryRepository _userCategoryRepository,
                                  IEventCategoryRepository _eventCategoryRepository,
                                  IEventPhotoRepository _eventPhotoRepository,
                                  IEventRepository _eventRepository,
                                  IEventVisitorsRepository _eventVisitorsRepository)
        {
            Database = db;
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
            LocationRepository = _locationRepository;
            ProfileManager = _profileManager;
            PhotoRepository = _photoRepository;
            CategoryRepository = _categoriesRepository;
            UserCategoryRepository = _userCategoryRepository;
            EventCategoryRepository = _eventCategoryRepository;
            EventPhotoRepository = _eventPhotoRepository;
            EventRepository = _eventRepository;
            EventVisitorsRepository = _eventVisitorsRepository;

        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    ProfileManager.Dispose();
                }
                this.disposed = true;
            }
        }

        public async Task SaveAsync()
        {
            await Database.SaveChangesAsync();
        }
    }
}
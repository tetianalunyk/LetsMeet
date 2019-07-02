using LetsTogether.DAL.EF;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace LetsTogether.DAL.Repositories
{
    public class ProfileManager : IProfileManager
    {
        private readonly AppDBContext Database;

        public ProfileManager(AppDBContext db)
        {
            Database = db;
        }

        public void Create(Profile profile)
        {
            Database.Profiles.Add(profile);
            Database.SaveChanges();
        }

        public Profile FindById(string id)
        {
            return Database.Profiles.FirstOrDefault(x => x.Id == id);
        }

        public User FindByUserName(string UserName)
        {
            User user = Database.Users.FirstOrDefault(x => x.UserName == UserName);
            user.Profile = Database.Profiles.FirstOrDefault(x => x.Id == user.Id);
            user.Profile.Avatar = Database.Photos.FirstOrDefault(x => x.Id == user.Profile.PhotoId);
            user.Profile.Location = Database.Locations.FirstOrDefault(x => x.Id == user.Profile.LocationId);
            return user;
        }


        public void Dispose()
        {                      
            Database.Dispose();
        }
    }
}

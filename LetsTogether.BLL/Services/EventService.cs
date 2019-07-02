using LetsTogether.BLL.DTO;
using LetsTogether.BLL.Infrastructure;
using LetsTogether.BLL.Interfaces;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LetsTogether.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork Database;
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IProfileService profileService;

        public EventService(
            IUnitOfWork db,
            IHostingEnvironment hostingEnvironment,
            IProfileService _profileService)
        {
            Database = db;
            _appEnvironment = hostingEnvironment;
            profileService = _profileService;
        }

        public async Task<OperationDetails> Add(EventDTO e)
        {
            Event Ev = e.Event;
            Location l = Database.LocationRepository.FindClone(e.Location);
                if (l == null)
                {
                    l = Database.LocationRepository.Add(e.Location);
                }
                Ev.Location = l;

            Ev.Owner = await Database.UserManager.FindByIdAsync(e.UserId);

            Ev = Database.EventRepository.Add(Ev);

            if (e.Photo != null)
            {
                // путь к папке Files
                string path = "/images/" + e.Photo.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await e.Photo.CopyToAsync(fileStream);
                }

                Photo photo = Database.PhotoRepository.Add(new Photo { Url = path });
                Database.EventPhotoRepository.Add(new EventPhoto
                {
                    Event = Ev,
                    Photo = photo
                });
            }
            else
            {
                Photo photo = Database.PhotoRepository.GetById(2);
                Database.EventPhotoRepository.Add(new EventPhoto
                {
                    Event = Ev,
                    Photo = photo
                });
            }
                       
            foreach (var item in e.Categories)
            {
                Database.EventCategoryRepository.Add(new EventCategory
                {
                    Event = Ev,
                    Category = Database.CategoryRepository.GetByTitle(item)
                });
            }

            Database.EventVisitorsRepository.Add(new EventVisitors
            {
                User = await Database.UserManager.FindByIdAsync(e.UserId),
                Event = Ev
            });

            await Database.SaveAsync();
            return new OperationDetails(true, "Ok", "");
        }

        public List<EventsDTO> GetEvents(string id)
        {
            List<EventsDTO> eventsDTO = new List<EventsDTO>();
            foreach (var even in Database.EventRepository.GetAll())
            {
                eventsDTO.Add(GetEvent(even, id));
            }
            return eventsDTO;
        }

        public EventsDTO GetEvent(Event even, string id)
        {
                Location l = Database.LocationRepository.GetById(even.LocationId);
                Photo photo = Database.PhotoRepository.GetById(Database.EventPhotoRepository.FindByEventId(even.Id).PhotoId);

                List<string> categories = new List<string>();
                foreach (var x in Database.EventCategoryRepository.FindByEventId(even.Id))
                {
                    categories.Add(Database.CategoryRepository.GetById(x.CategoryId).Name);
                }

               int flag = 1;
                EventVisitors visitor = Database.EventVisitorsRepository.FindEventById(even.Id, id);
            if (visitor == null)
                flag = -1;
            else if (id == even.OwnerId)
                flag = 0;
                EventsDTO eventsDto = new EventsDTO
                {
                    Id = even.Id,
                    Title = even.Title,
                    DateFrom = even.DateFrom,
                    DateTo = even.DateTo,
                    Description = even.Description,
                    OwnerId = even.OwnerId,
                    city_state = l.City,
                    country = l.Country,
                    url = photo.Url,
                    Categories = categories,
                    Ifigo = flag
                };
            return eventsDto;
        }

        public List<EventsDTO> AllEvents(string id)
        {
            List<EventsDTO> eventsDTO = new List<EventsDTO>();
            foreach (var even in Database.EventRepository.GetAll())
            {
                eventsDTO.Add(GetEvent(even, id));
            }
            return eventsDTO;
        }

        public void Visit(int id, string userId)
        {
            EventVisitors visitor = Database.EventVisitorsRepository.FindEventById(id, userId);
            if (visitor == null)
            {
                User user = Database.ProfileManager.FindById(userId).User;
                Event even = Database.EventRepository.GetById(id);
                Database.EventVisitorsRepository.Add(new EventVisitors
                {
                    User = user,
                    Event = even
                });
                Database.SaveAsync();
            }
        }

        public void NotVisit(int id, string userId)
        {
            EventVisitors visitor = Database.EventVisitorsRepository.FindEventById(id, userId);
            Database.EventVisitorsRepository.Delete(visitor);
            Database.SaveAsync();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

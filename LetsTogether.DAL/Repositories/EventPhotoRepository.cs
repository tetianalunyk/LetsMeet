using LetsTogether.DAL.EF;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsTogether.DAL.Repositories
{
    public class EventPhotoRepository : Repository<EventPhoto>, IEventPhotoRepository
    {
        public EventPhotoRepository(AppDBContext db) : base(db)
        {

        }
        public EventPhoto FindByEventId(int id)
        {
            return Database.EventPhotos.FirstOrDefault(x => x.EventId == id);
        }
    }
}

using LetsTogether.DAL.EF;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsTogether.DAL.Repositories
{
    public class EventCategoryRepository : Repository<EventCategory>, IEventCategoryRepository
    {
        public EventCategoryRepository(AppDBContext db) : base(db)
        {

        }
        public List<EventCategory> FindByEventId(int id)
        {
            return Database.EventCategories.Where(x => x.EventId == id).ToList();
        }
    }
}

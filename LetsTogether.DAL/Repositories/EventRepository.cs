using LetsTogether.DAL.EF;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsTogether.DAL.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(AppDBContext db) : base(db)
        {

        }

        public List<Event> Events(string id)
        {
            List<Event> events = new List<Event>();
            foreach (var item in Database.Events.Where(x => x.OwnerId == id))
            {
                events.Add(item);
            }
            return events;
        }
    }
}

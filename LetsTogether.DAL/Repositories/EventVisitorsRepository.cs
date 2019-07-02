using LetsTogether.DAL.EF;
using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsTogether.DAL.Repositories
{
    public class EventVisitorsRepository : Repository<EventVisitors>, IEventVisitorsRepository
    {
        public EventVisitorsRepository(AppDBContext db) : base(db)
        {

        }

        public EventVisitors FindEventById(int id, string userId)
        {
            List<EventVisitors> visitors = new List<EventVisitors>();
            visitors = Database.EventVisitors.Where(x => x.EventId == id).ToList();

            return visitors.FirstOrDefault(x => x.UserId == userId);
        }
    }
}

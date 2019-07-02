using LetsTogether.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsTogether.DAL.Interfaces
{
    public interface IEventVisitorsRepository : IRepository<EventVisitors>
    {
        EventVisitors FindEventById(int id, string userId);
    }
}

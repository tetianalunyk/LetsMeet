using LetsTogether.DAL.Entities;
using LetsTogether.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LetsTogether.DAL.Interfaces
{
    public interface IEventRepository : IRepository<Event>
    {
        List<Event> Events(string id);
    }
}

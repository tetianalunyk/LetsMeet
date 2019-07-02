using LetsTogether.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsTogether.DAL.Interfaces
{
    public interface IEventPhotoRepository : IRepository<EventPhoto>
    {
        EventPhoto FindByEventId(int id);
    }
}

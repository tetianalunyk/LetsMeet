using LetsTogether.BLL.DTO;
using LetsTogether.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetsTogether.BLL.Interfaces
{
    public interface IEventService : IDisposable
    {
        Task<OperationDetails> Add(EventDTO e);
        List<EventsDTO> GetEvents(string id);
        List<EventsDTO> AllEvents(string id);
        void Visit(int id, string userId);
        void NotVisit(int id, string userId);
    }
}

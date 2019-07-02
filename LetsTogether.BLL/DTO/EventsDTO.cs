using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsTogether.BLL.DTO
{
    public class EventsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string country { get; set; }
        public string city_state { get; set; }

        public string url { get; set; }
        public string OwnerId { get; set; }
        public string Description { get; set; }
        public List<string> Categories { get; set; }
        public int Ifigo { get; set; }

    }
}

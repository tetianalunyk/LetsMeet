using LetsTogether.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsTogether.BLL.DTO
{
    public class EventDTO
    {
        public Event Event { get; set; }
        public Location Location { get; set; }
        public List<string> Categories { get; set; }
        public IFormFile Photo { get; set; }
        public string UserId { get; set; }
    }
}

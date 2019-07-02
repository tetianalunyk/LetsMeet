using LetsTogether.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsTogether.BLL.DTO
{
    public class EditProfileDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public Location Location { get; set; }
        public DateTime Birthday { get; set; }
    }
}
﻿using LetsTogether.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsTogether.BLL.DTO
{
    public class ProfileDTO
    {
        public User GetUser { get; set; }
        public List<Event> Events { get; set; }
        public List<Category> Categories { get; set; }

    }
}

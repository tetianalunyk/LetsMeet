using LetsTogether.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LetsTogether.BLL.DTO
{
    public class UserCategoryDTO
    {
        public string Id { get; set; }
        public List<string> Categories { get; set; }
    }
}
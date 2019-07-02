using LetsTogether.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LetsTogether.Web.Models
{
    public class EditProfileModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string country { get; set; }
        public string city_state { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public List<Category> Categories { get; set; }
        public List<string> SelectedCategories { get; set; }
    }
}
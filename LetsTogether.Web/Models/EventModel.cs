using LetsTogether.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LetsTogether.Web.Models
{
    public class EventModel
    {
        [Required]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Required]
        public DateTime DateFrom { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateTo { get; set; }

      

        public string country { get; set; }
        public string city_state { get; set; }

        public IFormFile formFile { get; set; }

        public List<string> SelectedCategories { get; set; }
        public List<Category> Categories { get; set; }

        public string OwnerId { get; set; }

        public string Description { get; set; }
    }
}

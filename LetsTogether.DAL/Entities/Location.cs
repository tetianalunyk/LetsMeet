using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LetsTogether.DAL.Entities
{
    public class Location
    {

        [Key]
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}

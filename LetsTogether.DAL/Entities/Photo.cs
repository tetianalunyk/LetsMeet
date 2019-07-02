using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LetsTogether.DAL.Entities
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Url { get; set; }
    }
}

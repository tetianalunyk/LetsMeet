using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LetsTogether.DAL.Entities
{
    public class Event
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateFrom { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateTo { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        [ForeignKey("User")]
        public string OwnerId { get; set; }

        public string Description { get; set; }

        public virtual Location Location { get; set; }

        public virtual User Owner { get; set; }
    }
}

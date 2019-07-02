using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LetsTogether.DAL.Entities
{
    public class EventPhoto
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [ForeignKey("Photo")]
        public int PhotoId { get; set; }

        public virtual Event Event { get; set; }

        public virtual Photo Photo { get; set; }
    }
}

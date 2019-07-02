using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LetsTogether.DAL.Entities
{
    public class EventVisitors
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }

        public virtual User User { get; set; }

        public virtual Event Event { get; set; }
    }
}

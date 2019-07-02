using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LetsTogether.DAL.Entities
{
    public class Profile
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public string Gender { get; set; }
        [ForeignKey("Photo")]
        public int PhotoId { get; set; }

        public virtual User User { get; set; }

        public virtual Location Location { get; set; }

        public virtual Photo Avatar { get; set; }
    }
}

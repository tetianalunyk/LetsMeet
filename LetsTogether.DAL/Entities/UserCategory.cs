using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LetsTogether.DAL.Entities
{
    public class UserCategory
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual User User { get; set; }

        public virtual Category Category { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;                               
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LetsTogether.DAL.Entities
{
    public class User : IdentityUser
    {
        public virtual Profile Profile { get; set; }

    }
}

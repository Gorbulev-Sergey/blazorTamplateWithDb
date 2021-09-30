using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazorProject5.Models
{
    public class user : IdentityUser
    {
        public virtual List<post> posts { get; set; } = new List<post>();
    }
}

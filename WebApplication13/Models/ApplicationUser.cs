using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication13.Data;

namespace WebApplication13.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime Last_updated { get; set; }

    }
}

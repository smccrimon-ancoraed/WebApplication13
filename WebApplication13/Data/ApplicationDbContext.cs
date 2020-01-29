using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Models;

namespace WebApplication13.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication13.Models.Rental> Rental { get; set; }
        public DbSet<WebApplication13.Models.Film_text> Film_text { get; set; }
        public DbSet<WebApplication13.Models.Actor> Actor { get; set; }
    }
}

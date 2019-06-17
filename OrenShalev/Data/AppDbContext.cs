using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using OrenShalev.Models;

namespace OrenShalev.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Root> Roots { get; set; }

        public DbSet<Chapter> Chapters { get; set; }

    }
}

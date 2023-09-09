﻿using Microsoft.EntityFrameworkCore;

namespace MovieCrudUsingEF.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Movie> Movies { get; set; }
    }
}

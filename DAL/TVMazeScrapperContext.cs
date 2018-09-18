using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class TVMazeScrapperContext: DbContext
    {
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Show> Shows { get; set; }

        public TVMazeScrapperContext(DbContextOptions<TVMazeScrapperContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Show>().HasMany(e => e.Casts).WithOne().HasForeignKey(e=>e.ShowId);
        }
    }
}

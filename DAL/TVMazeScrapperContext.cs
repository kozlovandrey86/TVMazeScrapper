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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("Data Source=tvmazescrapper.db");
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using trackapiboom.Models;

namespace trackapiboom.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=OLUWAFISAYOMI;Database=TrackBoomAPI;Integrated Security=True");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
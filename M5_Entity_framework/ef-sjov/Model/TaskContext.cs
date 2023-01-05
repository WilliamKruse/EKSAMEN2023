using System;
using Microsoft.EntityFrameworkCore;

namespace ef_sjov.Model
{
  //Denne klasse er forbindelsen til databasen. 
    public class TaskContext : DbContext
    {
        public DbSet<TodoTask> Tasks { get; set; }
        public string DbPath { get; }

        public TaskContext()
        {
            DbPath = "bin/TodoTask.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoTask>().ToTable("Tasks");
        }
    }

}


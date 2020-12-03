using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireDemo.Models
{
    public partial class MyDbContext : DbContext
    {
        public virtual DbSet<CycleJob> CycleJob { get; set; }

        public virtual DbSet<CycleJobTask> CycleJobTask { get; set; }

        protected void ExtOnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CycleJob>(entity =>
            {
                entity.HasKey(e => new { e.Id });
            });

            modelBuilder.Entity<CycleJobTask>(entity =>
            {
                entity.HasKey(e => new { e.Id });
            });
        }
    }
}

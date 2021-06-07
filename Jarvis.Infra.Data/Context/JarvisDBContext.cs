using System;
using Jarvis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Jarvis.Infra.Data.Context
{
    public partial class JarvisDbContext : DbContext
    {
        public JarvisDbContext(DbContextOptions<JarvisDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Command>(entity =>
            {
                entity.Property(e => e.CommandId).HasDefaultValueSql("(newid())");
            });

        }
    }
}

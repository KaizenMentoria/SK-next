using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace workspace.Data
{
    using workspace.Models;

    public class SKDbContext : DbContext
    {
        public SKDbContext(DbContextOptions<SKDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Aluno>()
                .Property(a => a.CreationTimestamp)
                .HasDefaultValueSql("now()");
            modelBuilder
                .Entity<Turma>()
                .Property(a => a.CreationTimestamp)
                .HasDefaultValueSql("now()");
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
    }
}

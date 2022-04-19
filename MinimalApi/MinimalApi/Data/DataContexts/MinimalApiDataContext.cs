using Microsoft.EntityFrameworkCore;
using MinimalApi.Data.Mappings;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Data.DataContext
{
    public class MinimalApiDataContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }

        public MinimalApiDataContext(DbContextOptions<MinimalApiDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}

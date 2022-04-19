using Microsoft.EntityFrameworkCore;
using MinimalApi.Data.Mappings;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Data.DataContext
{
    public class MinimalApiDataContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public MinimalApiDataContext(DbContextOptions<MinimalApiDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}

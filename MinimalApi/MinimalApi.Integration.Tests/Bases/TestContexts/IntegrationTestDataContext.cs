using Microsoft.EntityFrameworkCore;
using MinimalApi.Data.Mappings;
using MinimalApi.Domain.Entities;

namespace ProjetoCompeticao.Integration.Tests.Bases.TestContexts
{
    public class IntegrationTestDataContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public IntegrationTestDataContext(DbContextOptions<IntegrationTestDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}

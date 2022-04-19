using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIO");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Login)
                   .IsRequired()
                   .HasColumnName("LOGIN_USUARIO")
                   .HasColumnType("varchar(30)");

            builder.Property(x => x.Senha)
                  .IsRequired()
                  .HasColumnName("SENHA_USUARIO")
                  .HasColumnType("varchar(10)");

            builder.Property(x => x.Permissao)
                  .IsRequired()
                  .HasColumnName("PERMISSAO_USUARIO")
                  .HasColumnType("varchar(10)");
        }
    }
}

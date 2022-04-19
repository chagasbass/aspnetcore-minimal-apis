using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("TB_ALUNO");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasColumnName("NOME_ALUNO")
                   .HasColumnType("varchar(200");

            builder.Property(x => x.Nome)
                  .IsRequired()
                  .HasColumnName("NOME_ALUNO")
                  .HasColumnType("varchar(200");

            builder.Property(x => x.Documento)
                  .IsRequired()
                  .HasColumnName("DOCUMENTO_ALUNO")
                  .HasColumnType("varchar(14)");

            builder.Property(x => x.Ativo)
                 .IsRequired()
                 .HasColumnName("ALUNO_ATIVO")
                 .HasColumnType("bit");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Models.Pessoa;

namespace Map.Data.Mappings
{
    public class PadrinhosMap : IEntityTypeConfiguration<Padrinho>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Padrinho> builder)
        {
            builder.ToTable("Padrinhos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome Padrinho")
                .HasMaxLength(80)
                .HasColumnType("NVARCHAR(80)");
            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnName("Telefone Padrinho")
                .HasMaxLength(30)
                .HasColumnType("NVARCHAR(30)");
        }
    }
}
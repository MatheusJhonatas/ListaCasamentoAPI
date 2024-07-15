using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Pessoa;
namespace Maps.Data.Mappings
{
    public class ConvidadosMap : IEntityTypeConfiguration<Convidado>
    {
        public void Configure(EntityTypeBuilder<Convidado> builder)
        {
            builder.ToTable("Convidados");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome Convidado")
                .HasMaxLength(80)
                .HasColumnType("NVARCHAR(80)");

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnName("Telefone Convidado")
                .HasMaxLength(30)
                .HasColumnType("NVARCHAR(30)");
            builder.Property(c => c.Familia)
                .IsRequired()
                .HasColumnName("Familia")
                .HasMaxLength(20)
                .HasColumnType("NVARCHAR(20)");
        }
    }
}
using System;
using Models.Pessoa.Noivo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Maps.Data.Mappings
{
    public class NoivosMap : IEntityTypeConfiguration<Noivo>
    {
        public void Configure(EntityTypeBuilder<Noivo> builder)
        {
            builder.ToTable("Noivos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome Noivo(a)")
                .HasMaxLength(100)
                .HasColumnType("NVARCHAR(100)");
            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnName("Telefone Noivo(a)")
                .HasMaxLength(25)
                .HasColumnType("NVARCHAR(25)");
            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email Noivo(a)")
                .HasMaxLength(50)
                .HasColumnType("NVARCHAR(50)");
        }
    }
}
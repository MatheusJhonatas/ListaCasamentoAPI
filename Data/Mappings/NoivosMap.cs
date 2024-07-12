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


        }
    }
}
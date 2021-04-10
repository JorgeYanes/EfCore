using EfCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCore.Data.Configuration
{
    class AlumnoConfiguration : IEntityTypeConfiguration<Alumno>
    {
        public void Configure(EntityTypeBuilder<Alumno> builder)
        {
            builder.Property(a => a.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(a => a.SurName)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGuF.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGuF.Infra.Mapping
{
    public class PhotoMapping : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(keyExpression: p => p.Id);

            builder.Property(p => p.ImageUrl).IsRequired().HasColumnType("varchar(500)");

            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(100)");

            builder.Property(p => p.Type).IsRequired().HasColumnType("varchar(100)");

            builder.Property(p => p.Description).IsRequired().HasColumnType("varchar(100)");

            builder.Property(p => p.Author).IsRequired().HasColumnType("varchar(100)");

            builder.Property(p => p.Title).IsRequired().HasColumnType("varchar(100)");
        }
    }
}

using ClaroCell.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaroCell.Infra.Map
{
    public class CellMapping : IEntityTypeConfiguration<Cell>
    {
        public void Configure(EntityTypeBuilder<Cell> builder)
        {

            builder.ToTable("Cell");
            builder.HasKey(obj => obj.Id);
            builder.Property(obj => obj.Id).ValueGeneratedOnAdd();

            builder.Property(obj => obj.Code)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder.Property(obj => obj.Price)
                .IsRequired();

            builder.Property(obj => obj.Model)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(obj => obj.Brand)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(obj => obj.Photo)
                .HasMaxLength(500)
                .IsRequired();

        }
    }
}

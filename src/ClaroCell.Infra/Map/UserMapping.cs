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
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(obj => obj.Id);
            builder.Property(obj => obj.Id).ValueGeneratedOnAdd();

            builder.Property(obj => obj.Login)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(obj => obj.Password)
                .HasMaxLength(8)
                .IsRequired();
        }
    }
}

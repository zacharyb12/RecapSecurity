using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Email)
                    .IsRequired();

            builder.Property(u => u.Lastname)
                .IsRequired()
                .HasMaxLength(80);


            builder.Property(u => u.Firstname)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(u => u.Role)
                .HasDefaultValue("user");

            builder.Property(u => u.Password)
                .IsRequired();
        }
    }
}
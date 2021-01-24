using MemoMap.Domain;
using MemoMap.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(i => i.Username).IsUnique();
            builder.Property(i => i.Username).IsRequired().HasMaxLength(256);
            builder.Property(i => i.Password).IsRequired().HasMaxLength(256);
            builder.Property(i => i.Email).IsRequired().HasMaxLength(256);
            builder.Property(i => i.isAdmin).IsRequired();
        }
    }
}

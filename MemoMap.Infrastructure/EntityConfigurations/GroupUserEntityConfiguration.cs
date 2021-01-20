using MemoMap.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.EntityConfigurations
{
    public class GroupUserEntityConfiguration: IEntityTypeConfiguration<GroupUser>
    {
        public GroupUserEntityConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<GroupUser> builder)
        {

            builder.Ignore(p => p.IsNotAdmin);
            builder.Property(p => p.IsAdmin).IsRequired();

            builder
                .HasOne(bc => bc.Group)
                .WithMany(b => b.GroupUsers)
                .HasForeignKey(bc => bc.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(bc => bc.User)
                .WithMany(c => c.GroupUsers)
                .HasForeignKey(bc => bc.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using MemoMap.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.EntityConfigurations
{
    public class UserMapEntityConfiguration: IEntityTypeConfiguration<UserMap>
    {
        public UserMapEntityConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<UserMap> builder)
        {


            builder
               .HasOne(bc => bc.User)
               .WithMany(b => b.UserMaps)
               .HasForeignKey(bc => bc.UserId);

            builder
                .HasOne(bc => bc.Map)
                .WithMany(c => c.UserMaps)
                .HasForeignKey(bc => bc.MapId);
        }
    }
}

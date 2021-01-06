using MemoMap.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.EntityConfigurations
{
    public class GroupEntityConfiguration: IEntityTypeConfiguration<Group>
    {
        public GroupEntityConfiguration()
        {
            
        }

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Ignore(g => g.FormattedDate);
            builder.Property(e => e.Name).IsRequired();
        }
    }
}

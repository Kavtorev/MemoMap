using System;
using System.Collections.Generic;
using System.Text;
using MemoMap.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MemoMap.Infrastructure.EntityConfigurations
{
    public class MapEntityConfiguration : IEntityTypeConfiguration<Map>
    {
        public MapEntityConfiguration() { }

        public void Configure(EntityTypeBuilder<Map> builder)
        {
            builder.Property(e => e.GroupId);
        }
    }
}

using MemoMap.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.EntityConfigurations
{
    public class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        public LocationEntityConfiguration() { }

        public void Configure(EntityTypeBuilder<Location> builder)
        {
            throw new NotImplementedException();
        }
    }
}

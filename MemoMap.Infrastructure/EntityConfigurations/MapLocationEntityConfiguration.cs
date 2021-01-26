using MemoMap.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.EntityConfigurations
{
    public class MapLocationEntityConfiguration: IEntityTypeConfiguration<MapLocation>
    {
        public MapLocationEntityConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<MapLocation> builder)
        {

            builder
               .HasOne(bc => bc.Map)
               .WithMany(b => b.MapLocations)
               .HasForeignKey(bc => bc.MapId)
               .OnDelete(DeleteBehavior.Cascade);


            builder
                .HasOne(bc => bc.Location)
                .WithMany(c => c.MapLocations)
                .HasForeignKey(bc => bc.LocationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

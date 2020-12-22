using MemoMap.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.EntityConfigurations
{
    public class MapRouteEntityConfiguration: IEntityTypeConfiguration<MapRoute>
    {
        public MapRouteEntityConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<MapRoute> builder)
        {
            builder.HasKey(bc => new { bc.MapId, bc.RouteId });

            builder
               .HasOne(bc => bc.Map)
               .WithMany(b => b.MapRoutes)
               .HasForeignKey(bc => bc.MapId);

            builder
                .HasOne(bc => bc.Route)
                .WithMany(c => c.MapRoutes)
                .HasForeignKey(bc => bc.RouteId);
        }
    }
}

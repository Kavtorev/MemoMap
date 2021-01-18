using MemoMap.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.EntityConfigurations
{
    public class InvitationEntityConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.Property(p => p.Date).IsRequired();

            //Cannot create a relationship between 'User.Invitations' and 'Invitation.Invited', 
            //    because there already is a relationship between 
            //    'User.Invitations' and 'Invitation.Invitor'.Navigation 
            //    properties can only participate in a single relationship

            builder
                .HasOne(bc => bc.Group)
                .WithMany(b => b.Invitations)
                .HasForeignKey(bc => bc.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // Invitor

            builder
                .HasOne(bc => bc.Inviting)
                .WithMany(c => c.InvitingInvitations)
                .HasForeignKey(bc => bc.InvitingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Invited

            builder
                .HasOne(bc => bc.Invited)
                .WithMany(c => c.InvitedInvitations)
                .HasForeignKey(bc => bc.InvitedId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

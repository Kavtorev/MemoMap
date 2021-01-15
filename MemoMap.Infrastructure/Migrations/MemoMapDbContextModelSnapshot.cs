﻿// <auto-generated />
using System;
using MemoMap.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MemoMap.Infrastructure.Migrations
{
    [DbContext(typeof(MemoMapDbContext))]
    partial class MemoMapDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MemoMap.Domain.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Thumbnail")
                        .HasColumnType("image");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("MemoMap.Domain.Models.GroupUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupUsers");
                });

            modelBuilder.Entity("MemoMap.Domain.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("MemoMap.Domain.Models.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("MapName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("MemoMap.Domain.Models.MapLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("MapId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("MapId");

                    b.ToTable("MapLocation");
                });

            modelBuilder.Entity("MemoMap.Domain.Models.MapRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MapId")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.HasIndex("RouteId");

                    b.ToTable("MapRoute");
                });

            modelBuilder.Entity("MemoMap.Domain.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("MemoMap.Domain.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("MemoMap.Domain.Models.UserMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MapId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMaps");
                });

            modelBuilder.Entity("MemoMap.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MemoMap.Domain.Models.GroupUser", b =>
                {
                    b.HasOne("MemoMap.Domain.Models.Group", "Group")
                        .WithMany("GroupUsers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MemoMap.Domain.User", "User")
                        .WithMany("GroupUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MemoMap.Domain.Models.Map", b =>
                {
                    b.HasOne("MemoMap.Domain.Models.Group", "Group")
                        .WithMany("Maps")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MemoMap.Domain.Models.MapLocation", b =>
                {
                    b.HasOne("MemoMap.Domain.Models.Location", "Location")
                        .WithMany("MapLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MemoMap.Domain.Models.Map", "Map")
                        .WithMany("MapLocations")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MemoMap.Domain.Models.MapRoute", b =>
                {
                    b.HasOne("MemoMap.Domain.Models.Map", "Map")
                        .WithMany("MapRoutes")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MemoMap.Domain.Models.Route", "Route")
                        .WithMany("MapRoutes")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MemoMap.Domain.Models.Note", b =>
                {
                    b.HasOne("MemoMap.Domain.Models.Location", "Location")
                        .WithMany("Notes")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("MemoMap.Domain.Models.UserMap", b =>
                {
                    b.HasOne("MemoMap.Domain.Models.Map", "Map")
                        .WithMany("UserMaps")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MemoMap.Domain.User", "User")
                        .WithMany("UserMaps")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

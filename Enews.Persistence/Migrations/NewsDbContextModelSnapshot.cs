﻿// <auto-generated />
using System;
using Enews.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Enews.Persistence.Migrations
{
    [DbContext(typeof(NewsDbContext))]
    partial class NewsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Enews.Domain.News", b =>
                {
                    b.Property<Guid>("NewsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("HeadLine")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("NewsId");

                    b.HasIndex("NewsId")
                        .IsUnique();

                    b.ToTable("News");
                });

            modelBuilder.Entity("Enews.Domain.NewsFile", b =>
                {
                    b.Property<Guid>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("NewsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("FileId");

                    b.HasIndex("FileId")
                        .IsUnique();

                    b.HasIndex("NewsId")
                        .IsUnique();

                    b.ToTable("NewsFiles");
                });

            modelBuilder.Entity("Enews.Domain.NewsFile", b =>
                {
                    b.HasOne("Enews.Domain.News", "News")
                        .WithOne("FileId")
                        .HasForeignKey("Enews.Domain.NewsFile", "NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("News");
                });

            modelBuilder.Entity("Enews.Domain.News", b =>
                {
                    b.Navigation("FileId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

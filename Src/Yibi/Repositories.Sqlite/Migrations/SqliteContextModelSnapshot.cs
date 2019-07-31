﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Yibi.Repositories.Sqlite;

namespace Yibi.Repositories.Sqlite.Migrations
{
    [DbContext(typeof(SqliteContext))]
    partial class SqliteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("Yibi.Core.Entities.Packages", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("TEXT COLLATE NOCASE")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.HasKey("Key");

                    b.HasIndex("Id");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("Yibi.Core.Entities.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Name");

                    b.Property<string>("Sno");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}

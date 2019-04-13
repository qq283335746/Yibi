﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Yibi.Repositories.PostgreSql;

namespace Yibi.Repositories.PostgreSql.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20190413093448_MigrationName")]
    partial class MigrationName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:citext", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Yibi.Repositories.Core.Entities.PackageInfo", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("citext")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.HasKey("Key");

                    b.HasIndex("Id");

                    b.ToTable("Packages");
                });
#pragma warning restore 612, 618
        }
    }
}

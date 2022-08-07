﻿// <auto-generated />
using BlazorComplator.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorComplator.Migrations
{
    [DbContext(typeof(QueryDbContext))]
    partial class QueryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorComplator.Models.Query", b =>
                {
                    b.Property<int>("QueryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QueryId"), 1L, 1);

                    b.Property<string>("ConnectorType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QueryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QueryText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QueryId");

                    b.ToTable("Queries");
                });
#pragma warning restore 612, 618
        }
    }
}

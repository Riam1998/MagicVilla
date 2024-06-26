﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using prueba1._0.Datos;

#nullable disable

namespace prueba1._0.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("prueba1._0.Modelos.NumeroVilla", b =>
                {
                    b.Property<int>("VillaNo")
                        .HasColumnType("int");

                    b.Property<string>("DetalleEspecial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("VillaNo");

                    b.HasIndex("VillaId");

                    b.ToTable("NumeroVillas");
                });

            modelBuilder.Entity("prueba1._0.Modelos.Prueba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detalle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagenUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MetrosCuadrados")
                        .HasColumnType("float");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocupantes")
                        .HasColumnType("int");

                    b.Property<double>("Tarifa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenidad = "",
                            Detalle = "Detalle de la Villa...",
                            FechaActualizacion = new DateTime(2024, 4, 30, 13, 56, 34, 788, DateTimeKind.Local).AddTicks(9122),
                            FechaCreacion = new DateTime(2024, 4, 30, 13, 56, 34, 788, DateTimeKind.Local).AddTicks(9108),
                            ImagenUrl = "",
                            MetrosCuadrados = 50.0,
                            Nombre = "Villa Real",
                            Ocupantes = 5,
                            Tarifa = 200.0
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            Detalle = "Detalle de la Villa...",
                            FechaActualizacion = new DateTime(2024, 4, 30, 13, 56, 34, 788, DateTimeKind.Local).AddTicks(9125),
                            FechaCreacion = new DateTime(2024, 4, 30, 13, 56, 34, 788, DateTimeKind.Local).AddTicks(9124),
                            ImagenUrl = "",
                            MetrosCuadrados = 40.0,
                            Nombre = "Premium Vista a la Piscina",
                            Ocupantes = 4,
                            Tarifa = 150.0
                        });
                });

            modelBuilder.Entity("prueba1._0.Modelos.NumeroVilla", b =>
                {
                    b.HasOne("prueba1._0.Modelos.Prueba", "IdPrueba")
                        .WithMany()
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdPrueba");
                });
#pragma warning restore 612, 618
        }
    }
}

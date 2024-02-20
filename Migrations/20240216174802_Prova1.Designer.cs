﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace foglietta.alice._5i.ProvaDb.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20240216174802_Prova1")]
    partial class Prova1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Prenotazione", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cognome")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataDiNascita")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("_Ruolo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("_Sesso")
                        .HasColumnType("INTEGER");

                    b.HasKey("Email");

                    b.ToTable("Prenotazioni");
                });

            modelBuilder.Entity("Prodotto", b =>
                {
                    b.Property<int>("_NomeP")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("quantita")
                        .HasColumnType("INTEGER");

                    b.HasKey("_NomeP");

                    b.ToTable("Prodotti");
                });
#pragma warning restore 612, 618
        }
    }
}
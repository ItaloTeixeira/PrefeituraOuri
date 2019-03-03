﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ouri.API.Data;

namespace Ouri.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190303134523_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("Ouri.API.Model.Escola", b =>
                {
                    b.Property<int>("EscolaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("Cidade");

                    b.Property<string>("Diretor");

                    b.Property<string>("Nome");

                    b.Property<string>("Rua");

                    b.HasKey("EscolaId");

                    b.ToTable("Escolas");
                });
#pragma warning restore 612, 618
        }
    }
}
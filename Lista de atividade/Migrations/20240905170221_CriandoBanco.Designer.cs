﻿// <auto-generated />
using System;
using Lista_de_atividade.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lista_de_atividade.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240905170221_CriandoBanco")]
    partial class CriandoBanco
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lista_de_atividade.Models.Categoria", b =>
                {
                    b.Property<string>("CategoriaID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NomeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaID");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriaID = "trabalho",
                            NomeId = "Trabalho"
                        },
                        new
                        {
                            CategoriaID = "casa",
                            NomeId = "Casa"
                        },
                        new
                        {
                            CategoriaID = "faculdade",
                            NomeId = "Faculdade"
                        },
                        new
                        {
                            CategoriaID = "compras",
                            NomeId = "Compras"
                        },
                        new
                        {
                            CategoriaID = "academia",
                            NomeId = "Academia"
                        });
                });

            modelBuilder.Entity("Lista_de_atividade.Models.Status", b =>
                {
                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NomeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = "aberto",
                            NomeId = "Aberto"
                        },
                        new
                        {
                            StatusId = "completo",
                            NomeId = "Completo"
                        });
                });

            modelBuilder.Entity("Lista_de_atividade.Models.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoriaId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DataDeVencimento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("Lista_de_atividade.Models.Tarefa", b =>
                {
                    b.HasOne("Lista_de_atividade.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}

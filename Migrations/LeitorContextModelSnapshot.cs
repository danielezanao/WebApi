﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using webapi.Data;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(LeitorContext))]
    partial class LeitorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("webapi.Model.Emprestimo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_devolucao");

                    b.Property<DateTime>("DataEmprestimo")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_emprestimo");

                    b.Property<int>("Id_leitor")
                        .HasColumnType("integer")
                        .HasColumnName("id_leitor");

                    b.Property<int>("Id_livro")
                        .HasColumnType("integer")
                        .HasColumnName("id_livro");

                    b.HasKey("Id");

                    b.ToTable("tb_emprestimo", (string)null);
                });

            modelBuilder.Entity("webapi.Model.Leitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("datanascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_leitor", (string)null);
                });

            modelBuilder.Entity("webapi.Model.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ano");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("autor");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("genero");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("tb_livro", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}

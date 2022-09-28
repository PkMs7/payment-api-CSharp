﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using teste_payment_api.src.Context;

#nullable disable

namespace testes.Migrations
{
    [DbContext(typeof(TesteVendasContext))]
    [Migration("20220928151722_TesteVendas")]
    partial class TesteVendas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("teste_payment_api.src.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DadosVendedorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProdutosVendidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusVenda")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DadosVendedorId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("teste_payment_api.src.Models.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("teste_payment_api.src.Models.Venda", b =>
                {
                    b.HasOne("teste_payment_api.src.Models.Vendedor", "DadosVendedor")
                        .WithMany()
                        .HasForeignKey("DadosVendedorId");

                    b.Navigation("DadosVendedor");
                });
#pragma warning restore 612, 618
        }
    }
}

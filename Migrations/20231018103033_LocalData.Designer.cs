﻿// <auto-generated />
using System;
using API_Gestao_Sock.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Gestao_Sock.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231018103033_LocalData")]
    partial class LocalData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_Gestao_Sock.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("senha");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("tipousuario");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("usuario");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Sales_System_API.Model.CarinhoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("VendaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CodigoProduto");

                    b.HasIndex("VendaId");

                    b.ToTable("Carinho");
                });

            modelBuilder.Entity("Sales_System_API.Model.MovimentosStockModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("MovimentosStock");
                });

            modelBuilder.Entity("Sales_System_API.Model.ProdutoModel", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Codigo");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Sales_System_API.Model.StockModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("PrecoUnitario")
                        .HasColumnType("float");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CodigoProduto");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Sales_System_API.Model.VendaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("PrecoPago")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("Sales_System_API.Model.CarinhoModel", b =>
                {
                    b.HasOne("Sales_System_API.Model.ProdutoModel", "ProdutoModel")
                        .WithMany()
                        .HasForeignKey("CodigoProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales_System_API.Model.VendaModel", "VendaModel")
                        .WithMany()
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProdutoModel");

                    b.Navigation("VendaModel");
                });

            modelBuilder.Entity("Sales_System_API.Model.MovimentosStockModel", b =>
                {
                    b.HasOne("Sales_System_API.Model.StockModel", "StockModel")
                        .WithMany()
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StockModel");
                });

            modelBuilder.Entity("Sales_System_API.Model.StockModel", b =>
                {
                    b.HasOne("Sales_System_API.Model.ProdutoModel", "ProdutoModel")
                        .WithMany()
                        .HasForeignKey("CodigoProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProdutoModel");
                });
#pragma warning restore 612, 618
        }
    }
}

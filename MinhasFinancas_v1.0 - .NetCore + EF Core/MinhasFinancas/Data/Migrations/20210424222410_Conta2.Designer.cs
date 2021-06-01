﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinhasFinancas.Data;

namespace MinhasFinancas.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210424222410_Conta2")]
    partial class Conta2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MinhasFinancas.Models.CategoriaDespesa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("CategoriaDespesa");
                });

            modelBuilder.Entity("MinhasFinancas.Models.Conta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PessoaID");

                    b.Property<int>("TipoContaID");

                    b.Property<string>("agencia")
                        .IsRequired();

                    b.Property<string>("conta")
                        .IsRequired();

                    b.Property<DateTime>("dataCadastro");

                    b.Property<DateTime>("dataUltimaAtualizacao");

                    b.Property<bool>("flagAtivo");

                    b.Property<string>("saldoEmConta");

                    b.HasKey("ID");

                    b.HasIndex("PessoaID");

                    b.HasIndex("TipoContaID");

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("MinhasFinancas.Models.FormaPagamento", b =>
                {
                    b.Property<int>("FormaPagamento_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("FormaPagamento_ID");

                    b.ToTable("FormaPagamento");
                });

            modelBuilder.Entity("MinhasFinancas.Models.FormaRecebimento", b =>
                {
                    b.Property<int>("FormaRecebimento_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("FormaRecebimento_ID");

                    b.ToTable("FormaRecebimento");
                });

            modelBuilder.Entity("MinhasFinancas.Models.Pessoa", b =>
                {
                    b.Property<int>("Pessoa_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TipoPessoaID");

                    b.Property<DateTime>("dataCadastro");

                    b.Property<DateTime>("dataUltimaAlteracao");

                    b.Property<string>("documento")
                        .HasMaxLength(18);

                    b.Property<bool>("flagCadastroAtivo");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Pessoa_ID");

                    b.HasIndex("TipoPessoaID");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("MinhasFinancas.Models.StatusDespesa", b =>
                {
                    b.Property<int>("StatusDespesa_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("StatusDespesa_ID");

                    b.ToTable("StatusDespesa");
                });

            modelBuilder.Entity("MinhasFinancas.Models.StatusInvestimento", b =>
                {
                    b.Property<int>("StatusInvestimento_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("StatusInvestimento_ID");

                    b.ToTable("StatusInvestimento");
                });

            modelBuilder.Entity("MinhasFinancas.Models.StatusMeta", b =>
                {
                    b.Property<int>("StatusMeta_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("StatusMeta_ID");

                    b.ToTable("StatusMeta");
                });

            modelBuilder.Entity("MinhasFinancas.Models.StatusReceita", b =>
                {
                    b.Property<int>("StatusReceita_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("StatusReceita_ID");

                    b.ToTable("StatusReceita");
                });

            modelBuilder.Entity("MinhasFinancas.Models.TipoConta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("ID");

                    b.ToTable("TipoConta");
                });

            modelBuilder.Entity("MinhasFinancas.Models.TipoInvestimento", b =>
                {
                    b.Property<int>("TipoInvestimento_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("TipoInvestimento_ID");

                    b.ToTable("TipoInvestimento");
                });

            modelBuilder.Entity("MinhasFinancas.Models.TipoPessoa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("ID");

                    b.ToTable("TipoPessoa");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MinhasFinancas.Models.Conta", b =>
                {
                    b.HasOne("MinhasFinancas.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MinhasFinancas.Models.TipoConta", "TipoConta")
                        .WithMany()
                        .HasForeignKey("TipoContaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MinhasFinancas.Models.Pessoa", b =>
                {
                    b.HasOne("MinhasFinancas.Models.TipoPessoa", "TipoPessoa")
                        .WithMany()
                        .HasForeignKey("TipoPessoaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
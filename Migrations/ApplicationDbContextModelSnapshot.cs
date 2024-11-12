﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using fisio_ltd_back.Models;

#nullable disable

namespace fisio_ltd_back.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("fisio_ltd_back.Models.DadosBasicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Altura")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("DataAvaliacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DiagnosticoClinico")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .HasColumnType("text");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("text");

                    b.Property<string>("Nacionalidade")
                        .HasColumnType("text");

                    b.Property<string>("Naturalidade")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("NumeroIdentidade")
                        .HasColumnType("text");

                    b.Property<decimal?>("Peso")
                        .HasColumnType("numeric");

                    b.Property<string>("Profissao")
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DadosBasicos");
                });

            modelBuilder.Entity("fisio_ltd_back.Models.DiagnosticoPrognostico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DadosBasicosId")
                        .HasColumnType("integer");

                    b.Property<string>("DiagnosticoFisio")
                        .HasColumnType("text");

                    b.Property<string>("PrognosticoFisio")
                        .HasColumnType("text");

                    b.Property<string>("Quantidade")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DiagnosticoPrognostico");
                });

            modelBuilder.Entity("fisio_ltd_back.Models.Exames", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DadosBasicosId")
                        .HasColumnType("integer");

                    b.Property<string>("ExameFisico")
                        .HasColumnType("text");

                    b.Property<string>("ExamesComplementares")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Exames");
                });

            modelBuilder.Entity("fisio_ltd_back.Models.FichaAnamnese", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DadosBasicosId")
                        .HasColumnType("integer");

                    b.Property<string>("HabitosVida")
                        .HasColumnType("text");

                    b.Property<string>("HistoriaDoencaAtual")
                        .HasColumnType("text");

                    b.Property<string>("HistoriaFamiliar")
                        .HasColumnType("text");

                    b.Property<string>("HistoriaPatologica")
                        .HasColumnType("text");

                    b.Property<string>("Queixa")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FichasAnamnese");
                });

            modelBuilder.Entity("fisio_ltd_back.Models.TratamentoProposto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DadosBasicosId")
                        .HasColumnType("integer");

                    b.Property<string>("Plano")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TratamentoProposto");
                });

            modelBuilder.Entity("fisio_ltd_back.Models.TratamentoStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Cancelado")
                        .HasColumnType("boolean");

                    b.Property<int>("DadosBasicosId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Finalizado")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("DadosBasicosId");

                    b.ToTable("TratamentoStatus");
                });

            modelBuilder.Entity("fisio_ltd_back.Models.TratamentoStatus", b =>
                {
                    b.HasOne("fisio_ltd_back.Models.DadosBasicos", "DadosBasicos")
                        .WithMany()
                        .HasForeignKey("DadosBasicosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DadosBasicos");
                });
#pragma warning restore 612, 618
        }
    }
}

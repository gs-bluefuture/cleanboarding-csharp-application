﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace MinalAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MinalAPI.Models.HistoricoLocalizacao", b =>
                {
                    b.Property<int>("LocalizacaoIdLocalizacao")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("IdHistorico")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("NavioIdNavio")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("HistoricoTimestamp")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("MonitoramentoOperacaoIdMonitoramento")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("MonitoramentoOperacaoOperacaoLastroIdOperacao")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("MonitoramentoOperacaoOperacaoLastroLocalizacaoIdLocalizacao")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("LocalizacaoIdLocalizacao", "IdHistorico", "NavioIdNavio");

                    b.HasIndex("NavioIdNavio");

                    b.HasIndex("MonitoramentoOperacaoIdMonitoramento", "MonitoramentoOperacaoOperacaoLastroIdOperacao", "MonitoramentoOperacaoOperacaoLastroLocalizacaoIdLocalizacao");

                    b.ToTable("HistoricosLocalizacao");
                });

            modelBuilder.Entity("MinalAPI.Models.Localizacao", b =>
                {
                    b.Property<int>("IdLocalizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLocalizacao"));

                    b.Property<double?>("Latitude")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<double?>("Longitude")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<string>("Porto")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("IdLocalizacao");

                    b.ToTable("Localizacoes");
                });

            modelBuilder.Entity("MinalAPI.Models.MonitoramentoOperacao", b =>
                {
                    b.Property<int>("IdMonitoramento")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("OperacaoLastroIdOperacao")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("OperacaoLastroLocalizacaoIdLocalizacao")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("MetricaTimestamp")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("NavioIdNavio")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("NomeMetrica")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double?>("ValorMetrica")
                        .HasColumnType("BINARY_DOUBLE");

                    b.HasKey("IdMonitoramento", "OperacaoLastroIdOperacao", "OperacaoLastroLocalizacaoIdLocalizacao");

                    b.HasIndex("NavioIdNavio");

                    b.HasIndex("OperacaoLastroIdOperacao", "OperacaoLastroLocalizacaoIdLocalizacao");

                    b.ToTable("MonitoramentosOperacao");
                });

            modelBuilder.Entity("MinalAPI.Models.Navio", b =>
                {
                    b.Property<int>("IdNavio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNavio"));

                    b.Property<double?>("CapacidadeLastro")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("TipoNavio")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("IdNavio");

                    b.ToTable("Navios");
                });

            modelBuilder.Entity("MinalAPI.Models.OperacaoLastro", b =>
                {
                    b.Property<int>("IdOperacao")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("LocalizacaoIdLocalizacao")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("NavioIdNavio")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("OperecaoTimestamp")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<double?>("QuantidadeAgua")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<string>("TipoOperacao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("IdOperacao", "LocalizacaoIdLocalizacao");

                    b.HasIndex("LocalizacaoIdLocalizacao");

                    b.HasIndex("NavioIdNavio");

                    b.ToTable("OperacoesLastro");
                });

            modelBuilder.Entity("MinalAPI.Models.HistoricoLocalizacao", b =>
                {
                    b.HasOne("MinalAPI.Models.Localizacao", "Localizacao")
                        .WithMany("HistoricosLocalizacao")
                        .HasForeignKey("LocalizacaoIdLocalizacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinalAPI.Models.Navio", "Navio")
                        .WithMany()
                        .HasForeignKey("NavioIdNavio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinalAPI.Models.MonitoramentoOperacao", "MonitoramentoOperacao")
                        .WithMany()
                        .HasForeignKey("MonitoramentoOperacaoIdMonitoramento", "MonitoramentoOperacaoOperacaoLastroIdOperacao", "MonitoramentoOperacaoOperacaoLastroLocalizacaoIdLocalizacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Localizacao");

                    b.Navigation("MonitoramentoOperacao");

                    b.Navigation("Navio");
                });

            modelBuilder.Entity("MinalAPI.Models.MonitoramentoOperacao", b =>
                {
                    b.HasOne("MinalAPI.Models.Navio", "Navio")
                        .WithMany("MonitoramentosOperacao")
                        .HasForeignKey("NavioIdNavio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinalAPI.Models.OperacaoLastro", "OperacaoLastro")
                        .WithMany()
                        .HasForeignKey("OperacaoLastroIdOperacao", "OperacaoLastroLocalizacaoIdLocalizacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Navio");

                    b.Navigation("OperacaoLastro");
                });

            modelBuilder.Entity("MinalAPI.Models.OperacaoLastro", b =>
                {
                    b.HasOne("MinalAPI.Models.Localizacao", "Localizacao")
                        .WithMany("OperacoesLastro")
                        .HasForeignKey("LocalizacaoIdLocalizacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinalAPI.Models.Navio", "Navio")
                        .WithMany("OperacoesLastro")
                        .HasForeignKey("NavioIdNavio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Localizacao");

                    b.Navigation("Navio");
                });

            modelBuilder.Entity("MinalAPI.Models.Localizacao", b =>
                {
                    b.Navigation("HistoricosLocalizacao");

                    b.Navigation("OperacoesLastro");
                });

            modelBuilder.Entity("MinalAPI.Models.Navio", b =>
                {
                    b.Navigation("MonitoramentosOperacao");

                    b.Navigation("OperacoesLastro");
                });
#pragma warning restore 612, 618
        }
    }
}

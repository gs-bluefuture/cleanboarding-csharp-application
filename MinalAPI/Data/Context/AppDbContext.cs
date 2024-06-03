using Microsoft.EntityFrameworkCore;
using MinalAPI.Data.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<HistoricoLocalizacao> HistoricosLocalizacao { get; set; }
    public DbSet<Localizacao> Localizacoes { get; set; }
    public DbSet<MonitoramentoOperacao> MonitoramentosOperacao { get; set; }
    public DbSet<Navio> Navios { get; set; }
    public DbSet<OperacaoLastro> OperacoesLastro { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HistoricoLocalizacao>()
            .HasKey(h => new { h.LocalizacaoIdLocalizacao, h.IdHistorico, h.NavioIdNavio });

        modelBuilder.Entity<MonitoramentoOperacao>()
            .HasKey(m => new { m.IdMonitoramento, m.OperacaoLastroIdOperacao, m.OperacaoLastroLocalizacaoIdLocalizacao });

        modelBuilder.Entity<OperacaoLastro>()
            .HasKey(o => new { o.IdOperacao, o.LocalizacaoIdLocalizacao });

        modelBuilder.Entity<Localizacao>()
            .HasKey(l => l.IdLocalizacao);

        modelBuilder.Entity<Navio>().HasKey(n => n.IdNavio);


        modelBuilder.Entity<HistoricoLocalizacao>()
            .HasOne(hl => hl.Localizacao)
            .WithMany(l => l.HistoricosLocalizacao)
            .HasForeignKey(hl => hl.LocalizacaoIdLocalizacao);

        modelBuilder.Entity<HistoricoLocalizacao>()
            .HasOne(hl => hl.MonitoramentoOperacao)
            .WithMany()
            .HasForeignKey(hl => new { hl.MonitoramentoOperacaoIdMonitoramento, hl.MonitoramentoOperacaoOperacaoLastroIdOperacao, hl.MonitoramentoOperacaoOperacaoLastroLocalizacaoIdLocalizacao });

        modelBuilder.Entity<HistoricoLocalizacao>()
            .HasOne(hl => hl.Navio)
            .WithMany()
            .HasForeignKey(hl => hl.NavioIdNavio);

        modelBuilder.Entity<MonitoramentoOperacao>()
            .HasOne(mo => mo.Navio)
            .WithMany(n => n.MonitoramentosOperacao)
            .HasForeignKey(mo => mo.NavioIdNavio);

        modelBuilder.Entity<MonitoramentoOperacao>()
            .HasOne(mo => mo.OperacaoLastro)
            .WithMany()
            .HasForeignKey(mo => new { mo.OperacaoLastroIdOperacao, mo.OperacaoLastroLocalizacaoIdLocalizacao });

        modelBuilder.Entity<OperacaoLastro>()
            .HasOne(ol => ol.Navio)
            .WithMany(n => n.OperacoesLastro)
            .HasForeignKey(ol => ol.NavioIdNavio);

        modelBuilder.Entity<OperacaoLastro>()
            .HasOne(ol => ol.Localizacao)
            .WithMany(l => l.OperacoesLastro)
            .HasForeignKey(ol => ol.LocalizacaoIdLocalizacao);

        modelBuilder.Entity<Navio>()
            .HasMany(n => n.OperacoesLastro)
            .WithOne(o => o.Navio)
            .HasForeignKey(o => o.NavioIdNavio);

        modelBuilder.Entity<Navio>()
            .HasMany(n => n.MonitoramentosOperacao)
            .WithOne(m => m.Navio)
            .HasForeignKey(m => m.NavioIdNavio);
    }
}

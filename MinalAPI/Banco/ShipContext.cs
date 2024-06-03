using Microsoft.EntityFrameworkCore;
using MinhaApiCrud.Models;

public class ShipContext : DbContext
{
    public ShipContext(DbContextOptions<ShipContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    //O nome do DbSET é o nome da tabela que vou realizar o crud
    public DbSet<Localizacao> Localizacao { get; set; }
    public DbSet<Navio> Navio { get; set; }
    public DbSet<OperacaoLastro> Operacao_lastro { get; set; }
    public DbSet<HistoricoLocalizacao> Historico_localizacao { get; set; }
    public DbSet<MonitoramentoOperacao> Monitoramento_operacao { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações de chaves primárias
        modelBuilder.Entity<Localizacao>().HasKey(l => l.IdLocalizacao);
        modelBuilder.Entity<Navio>().HasKey(n => n.IdNavio);  
        modelBuilder.Entity<OperacaoLastro>().HasKey(o => o.IdOperacao);
        modelBuilder.Entity<HistoricoLocalizacao>().HasKey(h => h.IdHistorico);
        modelBuilder.Entity<MonitoramentoOperacao>().HasKey(m => m.IdMonitoramento);

        // Relacionamento 1 para N: Localizacao -> OperacoesLastro
        modelBuilder.Entity<Localizacao>()
            .HasMany(l => l.OperacoesLastro)
            .WithOne(o => o.Localizacao)
            .HasForeignKey(o => o.IdLocalizacao);

        // Relacionamento 1 para N: Localizacao -> HistoricosLocalizacao
        modelBuilder.Entity<Localizacao>()
            .HasMany(l => l.HistoricoLocalizacoes)
            .WithOne(h => h.Localizacao)
            .HasForeignKey(h => h.IdLocalizacao);

        // Relacionamento 1 para N: Navio -> HistoricosLocalizacao
        modelBuilder.Entity<Navio>()
            .HasMany(n => n.HistoricoLocalizacoes)
            .WithOne(h => h.Navio)
            .HasForeignKey(h => h.IdNavio);

        // Relacionamento 1 para N: Navio -> MonitoramentosOperacao
        modelBuilder.Entity<Navio>()
            .HasMany(n => n.MonitoramentosOperacao)
            .WithOne(m => m.Navio)
            .HasForeignKey(m => m.IdNavio);

        // Relacionamento 1 para N: Navio -> OperacaoLastro
        modelBuilder.Entity<Navio>()
            .HasMany(n => n.OperacoesLastro)
            .WithOne(o => o.Navio)
            .HasForeignKey(o => o.IdNavio);

        // Relacionamento 1 para N: OperacaoLastro -> MonitoramentosOperacao
        modelBuilder.Entity<OperacaoLastro>()
            .HasMany(o => o.MonitoramentosOperacao)
            .WithOne(m => m.OperacaoLastro)
            .HasForeignKey(m => m.IdOperacao);

        // Relacionamento 1 para N: MonitoramentoOperacao -> HistoricoLocalizacao
        modelBuilder.Entity<MonitoramentoOperacao>()
            .HasMany(m => m.HistoricoLocalizacaos) 
            .WithOne(h => h.MonitoramentoOperacao) 
            .HasForeignKey(h => h.IdMonitoramento); 




    } 
}


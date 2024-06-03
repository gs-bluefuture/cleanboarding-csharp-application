using System;

namespace MinhaApiCrud.Models
{
    public class MonitoramentoOperacao
    {
        //Atributos
        public int IdMonitoramento { get; set; }
        public string? NomeMetrica { get; set; }
        public decimal? ValorMetrica { get; set; }
        public DateTime? MetricaTimestamp { get; set; }

        //IDs ou chaves estrangeiras para outras entidades relacionadas. 
        public Navio? Navio { get; set; }
        public int IdNavio { get; set; }
        public OperacaoLastro ?OperacaoLastro { get; set; }
        public int IdOperacao { get; set; }

        //Cada MonitoramentoOperacao pode ter varios  HistoricoLocalizacao (1 para N)
        public ICollection<HistoricoLocalizacao> HistoricoLocalizacaos { get; set; }
    }
}

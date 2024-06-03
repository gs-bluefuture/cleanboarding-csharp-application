using System;

namespace MinalAPI.Data.Models
{
    public class MonitoramentoOperacao
    {
        public int NavioIdNavio { get; set; }
        public int IdMonitoramento { get; set; }
        public string NomeMetrica { get; set; }
        public double? ValorMetrica { get; set; }
        public DateTime MetricaTimestamp { get; set; }
        public int OperacaoLastroIdOperacao { get; set; }
        public int OperacaoLastroLocalizacaoIdLocalizacao { get; set; }

        public Navio Navio { get; set; }
        public OperacaoLastro OperacaoLastro { get; set; }
    }
}

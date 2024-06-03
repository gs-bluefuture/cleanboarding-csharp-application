using System;

namespace MinalAPI.Data.Models
{
    public class HistoricoLocalizacao
    {
        public int LocalizacaoIdLocalizacao { get; set; }
        public int IdHistorico { get; set; }
        public DateTime HistoricoTimestamp { get; set; }
        public int MonitoramentoOperacaoIdMonitoramento { get; set; }
        public int NavioIdNavio { get; set; }
        public int MonitoramentoOperacaoOperacaoLastroIdOperacao { get; set; }
        public int MonitoramentoOperacaoOperacaoLastroLocalizacaoIdLocalizacao { get; set; }

        public Localizacao Localizacao { get; set; }
        public MonitoramentoOperacao MonitoramentoOperacao { get; set; }
        public Navio Navio { get; set; }

    }
}

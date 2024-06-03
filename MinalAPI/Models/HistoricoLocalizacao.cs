using System;

namespace MinhaApiCrud.Models
{
    public class HistoricoLocalizacao
    {
       // Atributos
        public int IdHistorico { get; set; }
        public DateTime HistoricoTimestamp { get; set; }


        //Pegando a chave primaria de Localizacao, Navio e Monitoramento Operacao
        public Localizacao ?Localizacao { get; set; }
        public int IdLocalizacao { get; set; }
        public Navio ?Navio { get; set; }
        public int IdNavio { get; set; }
        public MonitoramentoOperacao ?MonitoramentoOperacao { get; set; }
        public int IdMonitoramento { get; set; }
    }
}

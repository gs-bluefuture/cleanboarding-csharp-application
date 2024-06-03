using System.Collections.Generic;

namespace MinhaApiCrud.Models
{
    public class Navio
    {
        //Atributos
        public int ?IdNavio { get; set; }
        public string ?Nome { get; set; }
        public string ?TipoNavio { get; set; }
        public int? CapacidadeLastro { get; set; }

        //Cada Navio pode ter varios OperacoesLastro (1 para N)
        public ICollection<OperacaoLastro> OperacoesLastro { get; set; }
        //Cada Navio pode ter varios HistoricoLocalizacoes  (1 para N) 
        public ICollection<HistoricoLocalizacao> HistoricoLocalizacoes { get; set; }

        //Cada Navio pode ter varios MonitoramentosOperacao  (1 para N) 
        public ICollection<MonitoramentoOperacao> MonitoramentosOperacao { get; set; }
    }
}

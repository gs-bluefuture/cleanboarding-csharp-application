using System.Collections.Generic;

namespace MinalAPI.Data.Models
{
    public class Navio
    {
        public int IdNavio { get; set; }
        public string Nome { get; set; }
        public string TipoNavio { get; set; }
        public double? CapacidadeLastro { get; set; }

        public List<MonitoramentoOperacao> MonitoramentosOperacao { get; set; } = new List<MonitoramentoOperacao>();
        public List<OperacaoLastro> OperacoesLastro { get; set; } = new List<OperacaoLastro>();
    }
}

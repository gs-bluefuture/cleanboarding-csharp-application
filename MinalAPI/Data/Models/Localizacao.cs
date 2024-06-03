using System.Collections.Generic;

namespace MinalAPI.Data.Models
{
    public class Localizacao
    {
        public int IdLocalizacao { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Porto { get; set; }

        public List<OperacaoLastro> OperacoesLastro { get; set; }
        public List<HistoricoLocalizacao> HistoricosLocalizacao { get; set; }
    }
}

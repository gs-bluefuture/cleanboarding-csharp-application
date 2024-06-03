using System.Collections.Generic;

namespace MinhaApiCrud.Models
{
    public class Localizacao
    {
        //atributos
        public int IdLocalizacao { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Porto { get; set; }

        //Cada localização pode ter varios OperacoesLastro (1 para N)
        public ICollection<OperacaoLastro> ?OperacoesLastro { get; set; }

        //Cada localização pode ter varios HistoricoLocalizacoes (1 para N)
        public ICollection<HistoricoLocalizacao> ?HistoricoLocalizacoes { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace MinalAPI.Data.Models
{
    public class OperacaoLastro
    {
        public int NavioIdNavio { get; set; }
        public int IdOperacao { get; set; }
        public string TipoOperacao { get; set; }
        public double? QuantidadeAgua { get; set; }
        public DateTime OperecaoTimestamp { get; set; }
        public int LocalizacaoIdLocalizacao { get; set; }

        public Navio Navio { get; set; }
        public Localizacao Localizacao { get; set; }
    }
}

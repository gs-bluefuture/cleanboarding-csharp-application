using System;
using System.Collections.Generic;

namespace MinhaApiCrud.Models
{
    public class OperacaoLastro
    {
        //Atributos  
        public int IdOperacao { get; set; }
        public string? TipoOperacao { get; set; }
        public int? QuantidadeAgua { get; set; }
        public DateTime? OperecaoTimestamp { get; set; }

        //Pegando a chave primaria de Navio e Localizacao (N para 1)
        public Localizacao? Localizacao { get; set; }
        public int IdLocalizacao { get; set; }
        public Navio ?Navio { get; set; }
        public int IdNavio { get; set; }
    

        ////Cada OperaçãoLastro pode ter varios  MonitoramentosOperacao (1 para N)
        public ICollection<MonitoramentoOperacao> ?MonitoramentosOperacao { get; set; }
    }
}

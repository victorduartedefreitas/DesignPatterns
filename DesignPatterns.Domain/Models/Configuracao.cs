using System;

namespace DesignPatterns.Domain.Models
{
    public class Configuracao
    {
        public int CodigoAplicacao { get; set; }
        public string NomeAplicacao { get; set; }
        public DateTime DataCriacao { get; set; }

        public override string ToString()
        {
            return $"Código Aplicação: {this.CodigoAplicacao}; Nome: {this.NomeAplicacao}; Data de Criação: {this.DataCriacao}";
        }
    }
}

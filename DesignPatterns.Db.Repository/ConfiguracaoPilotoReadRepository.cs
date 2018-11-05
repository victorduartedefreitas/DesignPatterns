using DesignPatterns.Domain.Models;
using DesignPatterns.Domain.Repository;
using System;

namespace DesignPatterns.Db.Repository
{
    public class ConfiguracaoPilotoReadRepository : IConfiguracaoReadRepository
    {
        public Configuracao RecuperarConfiguracaoAtiva()
        {
            return new Configuracao
            {
                CodigoAplicacao = 1,
                NomeAplicacao = "Aplicação Piloto",
                DataCriacao = new DateTime(2018, 10, 01)
            };
        }
    }
}

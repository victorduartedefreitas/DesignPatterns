using DesignPatterns.Domain.Models;
using DesignPatterns.Domain.Repository;
using System;

namespace DesignPatterns.Db.Repository
{
    public class ConfiguracaoProducaoReadRepository : IConfiguracaoReadRepository
    {
        public Configuracao RecuperarConfiguracaoAtiva()
        {
            return new Configuracao
            {
                CodigoAplicacao = 2,
                NomeAplicacao = "Aplicação em Produção",
                DataCriacao = new DateTime(2018, 11, 05)
            };
        }
    }
}

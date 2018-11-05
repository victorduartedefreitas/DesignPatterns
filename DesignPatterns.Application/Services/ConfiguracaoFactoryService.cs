using DesignPatterns.Db.Repository;
using DesignPatterns.Domain.Repository;
using DesignPatterns.Domain.Services;
using DesignPatterns.Domain.ValueTypes;

namespace DesignPatterns.Application.Services
{
    public class ConfiguracaoFactoryService : IConfiguracaoFactoryService
    {
        private TiposSistema _tipoSistemaAtivo = TiposSistema.Piloto;

        public IConfiguracaoReadRepository CriarInstanciaRepositorio()
        {
            switch (_tipoSistemaAtivo)
            {
                case TiposSistema.Piloto:
                    return new ConfiguracaoPilotoReadRepository();
                case TiposSistema.Producao:
                    return new ConfiguracaoProducaoReadRepository();
                default:
                    return null;
            }
        }
    }
}

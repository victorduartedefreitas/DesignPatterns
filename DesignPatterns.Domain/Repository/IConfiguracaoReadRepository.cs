using DesignPatterns.Domain.Models;

namespace DesignPatterns.Domain.Repository
{
    public interface IConfiguracaoReadRepository
    {
        Configuracao RecuperarConfiguracaoAtiva();
    }
}

using DesignPatterns.Domain.Repository;

namespace DesignPatterns.Domain.Services
{
    public interface IConfiguracaoFactoryService
    {
        IConfiguracaoReadRepository CriarInstanciaRepositorio();
    }
}

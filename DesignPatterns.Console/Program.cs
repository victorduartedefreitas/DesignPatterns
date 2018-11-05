using System;
using DesignPatterns.Application.Services;
using DesignPatterns.Domain.Services;
using Microsoft.Extensions.DependencyInjection;


namespace DesignPatterns.ConsoleApplication
{
    class Program
    {
        static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            _serviceProvider = new ServiceCollection()
                .AddScoped<IConfiguracaoFactoryService, ConfiguracaoFactoryService>()
                .BuildServiceProvider();

            TestePadraoFactory();

            Console.ReadKey();
        }

        static void TestePadraoFactory()
        {
            Console.WriteLine("#####################################################");
            Console.WriteLine("TESTE DO PADRÃO 'FACTORY'");
            Console.WriteLine();

            var factory = _serviceProvider.GetService<IConfiguracaoFactoryService>();
            var configuracaoRepository = factory.CriarInstanciaRepositorio();

            var config = configuracaoRepository?.RecuperarConfiguracaoAtiva();

            if (config != null)
            {
                Console.WriteLine("Configuração Ativa:");
                Console.WriteLine(config);
            }
            else
                Console.WriteLine("Não foi possível recuperar uma configuração ativa.");

            Console.WriteLine();
            Console.WriteLine("#####################################################");
        }
    }
}

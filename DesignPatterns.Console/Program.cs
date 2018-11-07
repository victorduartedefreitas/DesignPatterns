using System;
using DesignPatterns.Application.Services;
using DesignPatterns.Domain.Models;
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
            TestePadraoMemento();

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

        static void TestePadraoMemento()
        {
            Console.WriteLine("#####################################################");
            Console.WriteLine("TESTE DO PADRÃO 'MEMENTO'");
            Console.WriteLine();

            Carro sandero2017 = new Carro(2016, 2017, "Sandero", "Renault", 41250.35);
            Carro uno2014 = new Carro(2014, 2014, "Uno", "Fiat", 30350.65);

            Console.WriteLine($"Situação inicial: {sandero2017}");
            Console.WriteLine();
            Console.WriteLine($"Situação inicial: {uno2014}");

            Console.WriteLine();

            sandero2017.ValorFIPE = 40985.00;
            Console.WriteLine($"Sandero após primeira alteração:\r\n{sandero2017}");
            Console.WriteLine();

            sandero2017.ValorFIPE = 40030.10;
            Console.WriteLine($"Sandero após segunda alteração:\r\n{sandero2017}");
            Console.WriteLine();

            sandero2017.Undo();
            Console.WriteLine($"Sandero após desfazer última alteração:\r\n{sandero2017}");
            Console.WriteLine();

            sandero2017.Undo();
            Console.WriteLine($"Sandero após desfazer novamete última alteração:\r\n{sandero2017}");

            Console.WriteLine();
            Console.WriteLine();

            uno2014.ValorFIPE = 30000.00;
            Console.WriteLine($"Uno após primeira alteração:\r\n{uno2014}");
            Console.WriteLine();

            uno2014.ValorFIPE = 29580.15;
            Console.WriteLine($"Uno após segunda alteração:\r\n{uno2014}");
            Console.WriteLine();

            uno2014.ValorFIPE = 27321.37;
            Console.WriteLine($"Uno após terceira alteração:\r\n{uno2014}");
            Console.WriteLine();

            uno2014.Undo();
            Console.WriteLine($"Uno após desfazer última alteração:\r\n{uno2014}");
            Console.WriteLine();

            uno2014.Undo();
            Console.WriteLine($"Uno após desfazer novamete última alteração:\r\n{uno2014}");
            Console.WriteLine();

            uno2014.Redo();
            Console.WriteLine($"Uno após refazer última alteração:\r\n{uno2014}");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("#####################################################");
        }
    }
}

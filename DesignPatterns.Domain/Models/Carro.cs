using System;

namespace DesignPatterns.Domain.Models
{
    public class Carro : MementoModel<CarroMemento>
    {
        #region Construtores

        public Carro(int anoFabricacao, int anoModelo, string modelo, string marca, double valorFIPE)
        {
            _anoFabricacao = anoFabricacao;
            _anoModelo = anoModelo;
            _modelo = modelo;
            _marca = marca;
            _valorFIPE = valorFIPE;
        }

        #endregion

        #region Variáveis Locais

        private int _anoFabricacao;
        private int _anoModelo;
        private string _modelo;
        private string _marca;
        private double _valorFIPE;

        #endregion

        #region Propriedades

        public int AnoFabricacao
        {
            get => _anoFabricacao;
            set
            {
                SaveCurrentState();
                _anoFabricacao = value;
            }
        }
        public int AnoModelo
        {
            get => _anoModelo;
            set
            {
                SaveCurrentState();
                _anoModelo = value;
            }
        }
        public string Modelo
        {
            get => _modelo;
            set
            {
                SaveCurrentState();
                _modelo = value;
            }
        }
        public string Marca
        {
            get => _marca;
            set
            {
                SaveCurrentState();
                _marca = value;
            }
        }

        public double ValorFIPE
        {
            get => _valorFIPE;
            set
            {
                SaveCurrentState();
                _valorFIPE = value;
            }
        }

        #endregion

        #region Implementação Model Memento

        public override void Redo()
        {
            var next = GetNextState();
            if (next == null)
                return;

            _anoFabricacao = next.AnoFabricacao;
            _anoModelo = next.AnoModelo;
            _modelo = next.Modelo;
            _marca = next.Marca;
            _valorFIPE = next.ValorFIPE;
        }

        public override void SaveCurrentState()
        {
            SetPreviousState(new CarroMemento(AnoFabricacao, AnoModelo, Modelo, Marca, ValorFIPE));
        }

        public override void Undo()
        {
            var prev = GetPreviousState();
            if (prev == null)
                return;

            SetNextState(new CarroMemento(AnoFabricacao, AnoModelo, Modelo, Marca, ValorFIPE));

            _anoFabricacao = prev.AnoFabricacao;
            _anoModelo = prev.AnoModelo;
            _modelo = prev.Modelo;
            _marca = prev.Marca;
            _valorFIPE = prev.ValorFIPE;
        }

        #endregion

        #region Regras de Negócio da classe

        public string Ligar()
        {
            return $"Carro ligado em {DateTime.Now}";
        }

        public string Desligar()
        {
            return $"Carro desligado em {DateTime.Now}";
        }

        public override string ToString()
        {
            return $"FICHA DE VEÍCULO.\r\n" +
                $"Marca: {Marca}\r\n" +
                $"Modelo: {Modelo}\r\n" +
                $"Ano Fabricação: {AnoFabricacao}\r\n" +
                $"Ano Modelo: {AnoModelo}\r\n" +
                $"Valor FIPE: R$ {ValorFIPE}";
        }

        #endregion
    }

    /// <summary>
    /// Classe Memento com as propriedades que serão permitidas desfazer/refazer
    /// </summary>
    public class CarroMemento : Memento
    {
        public CarroMemento(int anoFabricacao, int anoModelo, string modelo, string marca, double valorFIPE)
        {
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            Modelo = modelo;
            Marca = marca;
            ValorFIPE = valorFIPE;
        }

        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public double ValorFIPE { get; set; }
    }
}

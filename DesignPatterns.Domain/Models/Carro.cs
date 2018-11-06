using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Domain.Models
{
    public class Carro : MementoModel<Carro>
    {

        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }


        public override void RestoreState(Carro original)
        {
            throw new NotImplementedException();
        }

        public override void SaveState()
        {
            throw new NotImplementedException();
        }
    }
}

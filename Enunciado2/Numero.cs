using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enunciado2
{
    public class Numero
    {
        public int Valor { get; set; }

        public Numero(int valor)
        {
            Valor = valor;
        }

        public override string ToString()
        {
            return Valor.ToString();
        }
    }
}

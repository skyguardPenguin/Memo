using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Contador
    {
        private int _cuenta;
        public int Cuenta { get => _cuenta; }

        public Contador(int starts)
        {
            _cuenta = starts;
        }
        public void Incremento(int increment)
        {
            _cuenta += increment;
        }
        public void Reset()
        {
            _cuenta = 0;
        }
    }
}

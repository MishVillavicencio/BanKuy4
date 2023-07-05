using System;
using System.Collections.Generic;
using System.Text;

namespace BanKuy.Modelo
{
    public class transferencia
    {
        public int cuentaOrigen { get; set; }
        public double monto { get; set; }
        public int cuentaDestino { get; set; }

        public string banco { get; set; }
    }
}

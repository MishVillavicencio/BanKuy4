using System;
using System.Collections.Generic;
using System.Text;

namespace BanKuy.Modelo
{
    public class transaccionesHistorial
    {
     public   int idTransaccion { get; set; }
      public  int idCuentaOrigen { get; set; }
        public int idCuentaDestino { get; set; }
        public double monto { get; set; }
        public string idTipo { get; set; }
        public DateTime fechaTransaccion { get; set; }

    }
}

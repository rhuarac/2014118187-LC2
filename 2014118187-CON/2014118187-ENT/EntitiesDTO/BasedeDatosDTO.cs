using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_ENT.EntitiesDTO
{
    public class BasedeDatosDTO
    {
        public int BasedeDatosId { get; set; }
        public bool AutentificarCuenta { get; set; }
        public decimal ObtenerSaldoDisponible { get; set; }
        public decimal ObtenerSaldoTotal { get; set; }
        public decimal Debitar { get; set; }
        public decimal Acreditar { get; set; }
        //Cuenta
        public int CuentaId { get; set; }
        
        //ATM
        public int ATMId { get; set; }
        
        //Retiro
        public int RetiroId { get; set; }
        
    }
}

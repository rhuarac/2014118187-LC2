using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014118187_ENT.Entities
{
    public class Cuenta
    {
        public int NumeroCuenta { get; set; }
        public int Pin { get; set; }
        public int CuentaId { get; set; }



        //Retiro
        public List<Retiro> Retiros { get; set; }

        public Cuenta()
        {
            Retiros = new List<Retiro>();
        }

    }
}

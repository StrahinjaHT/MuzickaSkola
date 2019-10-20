using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;
using System.ComponentModel;

namespace SistemskeOperacije.U
{
    public class VratiSveUcenike : OpstaSO
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            return Sesija.Broker.dajSesiju().vratiSve(odo).OfType<Ucenik>().ToList<Ucenik>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;

namespace SistemskeOperacije.PR
{
    public class KreirajPredavanje : OpstaSO
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Predavanje p = odo as Predavanje;
            p.PredavanjeID = Sesija.Broker.dajSesiju().vratiSifru(p);
            Sesija.Broker.dajSesiju().sacuvaj(p);
            return p;
        }
    }
}

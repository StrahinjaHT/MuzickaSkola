using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;

namespace SistemskeOperacije.PR
{
    public class ZapamtiPredavanje : OpstaSO
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Sesija.Broker.dajSesiju().izmeni(odo);
            Predavanje p = odo as Predavanje;
            Prisustvuje pr = new Prisustvuje();
            pr.Predavanje = p;

          //  Sesija.Broker.dajSesiju().obrisiZaUslovVise(pr);
            foreach(Prisustvuje pri in p.ListaUcenika)
            {
                Sesija.Broker.dajSesiju().sacuvaj(pri);
            }
            return 1;
        }
    }
}

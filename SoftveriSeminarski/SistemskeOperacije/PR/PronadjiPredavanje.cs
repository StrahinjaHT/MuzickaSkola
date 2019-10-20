using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;

namespace SistemskeOperacije.PR
{
    public class PronadjiPredavanje : OpstaSO
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Predavanje p = Sesija.Broker.dajSesiju().vratiZaUslovJedan(odo) as Predavanje;
            Prisustvuje pr = new Prisustvuje();
            pr.Predavanje = p;
            p.ListaUcenika = Sesija.Broker.dajSesiju().vratiSveZaUslovVise(pr).OfType<Prisustvuje>().ToList<Prisustvuje>();
            return p;
        }
    }
}

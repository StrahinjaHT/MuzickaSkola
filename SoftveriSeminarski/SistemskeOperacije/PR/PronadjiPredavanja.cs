using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;

namespace SistemskeOperacije.PR
{
    public class PronadjiPredavanja : OpstaSO
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            //return Sesija.Broker.dajSesiju().vratiSveZaUslovVise(odo).OfType<Predavanje>().ToList<Predavanje>();

            List<Predavanje> lista = Sesija.Broker.dajSesiju().vratiSveZaUslovVise(odo).OfType<Predavanje>().ToList<Predavanje>();


            foreach (Predavanje p in lista)
            {
                Prisustvuje pr = new Prisustvuje();
                pr.Predavanje = p;
                p.ListaUcenika = Sesija.Broker.dajSesiju().vratiSveZaUslovVise(pr).OfType<Prisustvuje>().ToList<Prisustvuje>();
            }
            return lista;
        }
    }
}

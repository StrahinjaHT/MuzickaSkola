using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;

namespace SistemskeOperacije.PR
{
    public class VratiSvaPredavanja : OpstaSO
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            List<Predavanje> lista = Sesija.Broker.dajSesiju().vratiSve(odo).OfType<Predavanje>().ToList<Predavanje>();


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

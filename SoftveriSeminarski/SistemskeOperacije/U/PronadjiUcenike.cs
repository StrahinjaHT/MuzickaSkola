using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;

namespace SistemskeOperacije.U
{
    public class PronadjiUcenike : OpstaSO
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            //   return Sesija.Broker.dajSesiju().vratiSveZaUslovVise(odo).OfType<Ucenik>().ToList<Ucenik>();
            List<Ucenik> lista = Sesija.Broker.dajSesiju().vratiSveZaUslovVise(odo).OfType<Ucenik>().ToList<Ucenik>();
            foreach (Ucenik u in lista)
            {
                Odsek o = new Odsek();
                o.OdsekID = u.Odsek.OdsekID;
                u.Odsek = Sesija.Broker.dajSesiju().vratiZaUslovJedan(o) as Odsek;

            }
            return lista;
        }
    }
}

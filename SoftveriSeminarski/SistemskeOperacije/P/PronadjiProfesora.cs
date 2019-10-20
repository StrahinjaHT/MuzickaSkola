using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;

namespace SistemskeOperacije.P
{
    public class PronadjiProfesora : OpstaSO
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            //  return Sesija.Broker.dajSesiju().vratiZaUslovJedan(odo) as Profesor;
            Profesor p = Sesija.Broker.dajSesiju().vratiZaUslovJedan(odo) as Profesor;
            Predaje pr = new Predaje();
            pr.Profesor = p;
            p.ListaPredmeta= Sesija.Broker.dajSesiju().vratiSveZaUslovJedan(pr).OfType<Predaje>().ToList<Predaje>();
            return p;
        }
    }
}

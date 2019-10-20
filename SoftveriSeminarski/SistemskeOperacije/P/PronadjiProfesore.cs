using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;

namespace SistemskeOperacije.P
{
    public class PronadjiProfesore : OpstaSO
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
          //  return Sesija.Broker.dajSesiju().vratiSveZaUslovVise(odo).OfType<Profesor>().ToList<Profesor>();
            List<Profesor> lista= Sesija.Broker.dajSesiju().vratiSveZaUslovVise(odo).OfType<Profesor>().ToList<Profesor>();
            foreach (Profesor p in lista)
            {
                Predaje pr = new Predaje();
                pr.Profesor = p;
                p.ListaPredmeta = Sesija.Broker.dajSesiju().vratiSveZaUslovJedan(pr).OfType<Predaje>().ToList<Predaje>();
            }
            return lista;
        }
    }
}

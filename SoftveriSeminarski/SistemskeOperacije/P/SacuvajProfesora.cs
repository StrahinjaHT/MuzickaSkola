using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;

namespace SistemskeOperacije.P
{
    public class SacuvajProfesora : OpstaSO
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Sesija.Broker.dajSesiju().sacuvaj(odo);
            Profesor p = odo as Profesor;
            Predaje pr = new Predaje();
            pr.Profesor = p;

            Sesija.Broker.dajSesiju().obrisi(pr);
            foreach(Predaje pre in p.ListaPredmeta)
            {
                Sesija.Broker.dajSesiju().sacuvaj(pre);
            }
            return 1;

        }
    }
}

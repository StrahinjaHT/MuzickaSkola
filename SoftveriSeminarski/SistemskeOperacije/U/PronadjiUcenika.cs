using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteka;
using SistemskeOperacije.O;

namespace SistemskeOperacije.U
{
    public class PronadjiUcenika : OpstaSO
    {
        public override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            return Sesija.Broker.dajSesiju().vratiZaUslovJedan(odo) as Ucenik;
            
            //Ucenik u = Sesija.Broker.dajSesiju().vratiZaUslovJedan(odo) as Ucenik;
            //Odsek o = new Odsek();
            //o.OdsekID = u.Odsek.OdsekID;
            //u.Odsek=Sesija.Broker.dajSesiju().vratiZaUslovJedan(o) as Odsek;
            //return u;
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Biblioteka;
using Sesija;
using SistemskeOperacije.U;
using SistemskeOperacije.P;
using SistemskeOperacije.PR;
using SistemskeOperacije.O;
using SistemskeOperacije.R;

namespace Server
{
    class Obrada
    {
        private NetworkStream tok;
        BinaryFormatter formater;

        public Obrada(NetworkStream tok)
        {
            this.tok = tok;
            formater = new BinaryFormatter();

            ThreadStart ts = obradi;
            Thread nit = new Thread(ts);
            nit.Start();
        }

        public void obradi()
        {
            try
            {
                while (tok!=null)
                {
                    int operacija = 0;
                    while (operacija != (int)Operacije.Kraj)
                    {
                        TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;
                        switch (transfer.Operacija)
                        {
                            case Operacije.PronadjiUcenika:
                                PronadjiUcenika pu = new PronadjiUcenika();
                                transfer.Rezultat = pu.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.PronadjiProfesora:
                                PronadjiProfesora pp = new PronadjiProfesora();
                                transfer.Rezultat = pp.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.PronadjiUcenike:
                                PronadjiUcenike pue = new PronadjiUcenike();
                                transfer.Rezultat = pue.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.PronadjiProfesore:
                                PronadjiProfesore ppe = new PronadjiProfesore();
                                transfer.Rezultat = ppe.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.VratiSveProfesore:
                                VratiSveProfesore vsp = new VratiSveProfesore();
                                transfer.Rezultat = vsp.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.VratiSvaPredavanja:
                                VratiSvaPredavanja vspre = new VratiSvaPredavanja();
                                transfer.Rezultat = vspre.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.PronadjiPredavanje:
                                PronadjiPredavanje pppp = new PronadjiPredavanje();
                                transfer.Rezultat = pppp.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.VratiSveUcenike:
                                VratiSveUcenike vsu = new VratiSveUcenike();
                                transfer.Rezultat = vsu.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.VratiSveOdseke:
                                VratiSveOdseke vso = new VratiSveOdseke();
                                transfer.Rezultat = vso.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.VratiSvePredmete:
                                VratiSvePredmete vspr = new VratiSvePredmete();
                                transfer.Rezultat = vspr.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.ObrisiUcenika:
                                ObrisiUcenika ou = new ObrisiUcenika();
                                transfer.Rezultat = ou.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.ObrisiPredavanje:
                                ObrisiPredavanje opr = new ObrisiPredavanje();
                                transfer.Rezultat = opr.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.ObrisiProfesora:
                                ObrisiProfesora op = new ObrisiProfesora();
                                transfer.Rezultat = op.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.ZapamtiUcenika:
                                ZapamtiUcenika zu = new ZapamtiUcenika();
                                transfer.Rezultat = zu.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.SacuvajUcenika:
                                SacuvajUcenika su = new SacuvajUcenika();
                                transfer.Rezultat = su.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.SacuvajProfesora:
                                SacuvajProfesora sp = new SacuvajProfesora();
                                transfer.Rezultat = sp.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.KreirajPredavanje:
                                KreirajPredavanje kp = new KreirajPredavanje();
                                transfer.Rezultat = kp.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.ZapamtiPredavanje:
                                ZapamtiPredavanje zp = new ZapamtiPredavanje();
                                transfer.Rezultat = zp.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.PronadjiPredavanja:
                                PronadjiPredavanja ppr = new PronadjiPredavanja();
                                transfer.Rezultat = ppr.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.PronadjiRadnika:
                                PronadjiRadnika pr = new PronadjiRadnika();
                                transfer.Rezultat = pr.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                                formater.Serialize(tok, transfer);
                                break;
                            case Operacije.Kraj:
                                operacija = 1;
                                break;
                            default:
                                break;
                        }
                    } 
                }
            }
            catch (Exception)
            {

                Console.Write("Pukla konekcija.");
            }
        }
    }
}

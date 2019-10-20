using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Biblioteka;
using System.ComponentModel;

namespace Komunikacija
{
    public class Komunikacija
    {
        TcpClient klijent;
        NetworkStream tok;
        BinaryFormatter formater;

        public bool poveziSeNaServer()
        {
            try
            {
                klijent = new TcpClient("127.0.0.1", 10000);
                tok = klijent.GetStream();
                formater = new BinaryFormatter();
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }
        public Radnik pronadjiRadnika(Radnik r)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.PronadjiRadnika;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as Radnik;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public void kraj()
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.Kraj;
                formater.Serialize(tok, transfer);
            }
            catch (Exception)
            {

                return;
            }
        }
        public Ucenik pronadjiUcenika(Ucenik u)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.PronadjiUcenika;
                transfer.TransferObjekat = u;
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat as Ucenik;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public Profesor pronadjiProfesora(Profesor p)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.PronadjiProfesora;
                transfer.TransferObjekat = p;
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat as Profesor;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public Predavanje pronadjiPredavanje(Predavanje p)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.PronadjiPredavanje;
                transfer.TransferObjekat = p;
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat as Predavanje;
            }
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }

        }
        public List<Ucenik> vratiSveUcenike()
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.VratiSveUcenike;
                transfer.TransferObjekat = new Ucenik();
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat as List<Ucenik>;
            }
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }

        }
        public List<Odsek> vratiSveOdseke()
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.VratiSveOdseke;
                transfer.TransferObjekat = new Odsek();
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat as List<Odsek>;
            }

            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public List<Predmet> vratiSvePredmete()
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.VratiSvePredmete;
                transfer.TransferObjekat = new Predmet();
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat as List<Predmet>;
            }
           
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public List<Predavanje> vratiSvaPredavanja()
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.VratiSvaPredavanja;
                transfer.TransferObjekat = new Predavanje();
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat as List<Predavanje>;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public List<Profesor> vratiSveProfesore()
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.VratiSveProfesore;
                transfer.TransferObjekat = new Profesor();
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat as List<Profesor>;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public Object obrisiUcenika(Ucenik u)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.ObrisiUcenika;
                transfer.TransferObjekat = u;
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public Object obrisiProfesora(Profesor p)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.ObrisiProfesora;
                transfer.TransferObjekat = p;
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public Object obrisiPredavanje(Predavanje p)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.ObrisiPredavanje;
                transfer.TransferObjekat = p;
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public Object zapamtiUcenika(Ucenik u)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.ZapamtiUcenika;
                transfer.TransferObjekat = u;
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }

            
        }
        public List<Ucenik> pronadjiUcenike(Ucenik u)
        {

            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.PronadjiUcenike;
                transfer.TransferObjekat = u;
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat as List<Ucenik>;
            }
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
            
            
        }
        public List<Profesor> pronadjiProfesore(Profesor p)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.PronadjiProfesore;
                transfer.TransferObjekat = p;
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat as List<Profesor>;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public Object sacuvajUcenika(Ucenik u)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.SacuvajUcenika;
                transfer.TransferObjekat = u;
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public Object sacuvajProfesora(Profesor p)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.SacuvajProfesora;
                transfer.TransferObjekat = p;
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public Predavanje kreirajPredavanje()
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.KreirajPredavanje;
                transfer.TransferObjekat = new Predavanje();
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat as Predavanje;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public Object zapamtiPredavanje(Predavanje p)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.ZapamtiPredavanje;
                transfer.TransferObjekat = p;
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
        public List<Predavanje> pronadjiPredavanja(Predavanje p)
        {
            try
            {
                TransferKlasa transfer = new TransferKlasa();
                transfer.Operacija = Operacije.PronadjiPredavanja;
                transfer.TransferObjekat = p;
                formater.Serialize(tok, transfer);

                transfer = formater.Deserialize(tok) as TransferKlasa;
                return transfer.Rezultat as List<Predavanje>;
            }
            
            catch (Exception)
            {
                klijent.Close();
                tok.Dispose();
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Biblioteka;

namespace Sesija
{
    public class Broker
    {
        OleDbConnection konekcija;
        OleDbCommand komanda;
        OleDbTransaction transakcija;

        public static Broker instanca;
        public static Broker dajSesiju()
        {
            if (instanca == null) instanca = new Broker();
            return instanca;
        }
        public Broker()
        {
            otvoriKonekciju();
        }


        public void otvoriKonekciju()
        {
            try
            {
                konekcija = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Strahinja\Desktop\SoftveriSeminarski\Baza.accdb");
                konekcija.Open();
            }
            catch (Exception)
            {

                MessageBox.Show("Neuspesna konekcija.");
            }
        }
        public void zatvoriKonekciju()
        {
            try
            {
                konekcija.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Neuspesno zatvaranje konekcije.");
            }
        }
        public void zapocniTransakciju()
        {
            try
            {
                transakcija = konekcija.BeginTransaction();
            }
            catch (Exception)
            {

                MessageBox.Show("Neuspesna transakcija.");
            }
        }
        public void ponistiTransakciju()
        {
            try
            {
                transakcija.Rollback();
            }
            catch (Exception)
            {

                MessageBox.Show("Neuspesno ponistavanje transakcije.");
            }
        }
        public void potvrdiTransakciju()
        {
            try
            {
                transakcija.Commit();
            }
            catch (Exception)
            {

                MessageBox.Show("Neuspesna potvrda transakcije.");
            }
        }

        public List<OpstiDomenskiObjekat> vratiSve(OpstiDomenskiObjekat odo)
        {
            string upit = "SELECT * FROM " + odo.tabela;
            OleDbDataReader citac = null;
            komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                citac = komanda.ExecuteReader();
                DataTable tabela = new DataTable();
                tabela.Load(citac);
                List<OpstiDomenskiObjekat> lista = new List<OpstiDomenskiObjekat>();
                foreach(DataRow red in tabela.Rows)
                {
                    OpstiDomenskiObjekat pom = odo.napuni(red);
                    lista.Add(pom);
                }
                return lista;
            }
            catch (Exception)
            {

                throw new Exception("Greska u radu sa bazom.");
            }
            finally
            {
                if(citac!=null)
                {
                    citac.Close();
                }
            }
        }
        public List<OpstiDomenskiObjekat> vratiSveZaUslovVise(OpstiDomenskiObjekat odo)
        {
            string upit = "SELECT * FROM " + odo.tabela+" WHERE "+odo.uslovVise;
            OleDbDataReader citac = null;
            komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                citac = komanda.ExecuteReader();
                DataTable tabela = new DataTable();
                tabela.Load(citac);
                List<OpstiDomenskiObjekat> lista = new List<OpstiDomenskiObjekat>();
                foreach (DataRow red in tabela.Rows)
                {
                    OpstiDomenskiObjekat pom = odo.napuni(red);
                    lista.Add(pom);
                }
                return lista;
            }
            catch (Exception)
            {

                throw new Exception("Greska u radu sa bazom.");
            }
            finally
            {
                if (citac != null)
                {
                    citac.Close();
                }
            }
        }
        public List<OpstiDomenskiObjekat> vratiSveZaUslovJedan(OpstiDomenskiObjekat odo) //SAMO ZA PREDAJE
        {
            string upit = "SELECT * FROM " + odo.tabela + " WHERE " + odo.uslovJedan;
            OleDbDataReader citac = null;
            komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                citac = komanda.ExecuteReader();
                DataTable tabela = new DataTable();
                tabela.Load(citac);
                List<OpstiDomenskiObjekat> lista = new List<OpstiDomenskiObjekat>();
                foreach (DataRow red in tabela.Rows)
                {
                    OpstiDomenskiObjekat pom = odo.napuni(red);
                    lista.Add(pom);
                }
                return lista;
            }
            catch (Exception)
            {

                throw new Exception("Greska u radu sa bazom.");
            }
            finally
            {
                if (citac != null)
                {
                    citac.Close();
                }
            }
        }
        public OpstiDomenskiObjekat vratiZaUslovJedan(OpstiDomenskiObjekat odo)
        {
            string upit = "SELECT * FROM " + odo.tabela + " WHERE " + odo.uslovJedan;
            OleDbDataReader citac = null;
            komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                citac = komanda.ExecuteReader();
                DataTable tabela = new DataTable();
                tabela.Load(citac);
                DataRow red;
                if(tabela.Rows.Count==0)
                {
                    return null;
                }
                else
                {
                    red = tabela.Rows[0];
                }
                return odo.napuni(red);
            }
            catch (Exception)
            {

                throw new Exception("Greska u radu sa bazom.");
            }
            finally
            {
                if (citac != null)
                {
                    citac.Close();
                }
            }
        }
        public OpstiDomenskiObjekat vratiZaUslovVise(OpstiDomenskiObjekat odo)
        {
            string upit = "SELECT * FROM " + odo.tabela + " WHERE " + odo.uslovVise;
            OleDbDataReader citac = null;
            komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                citac = komanda.ExecuteReader();
                DataTable tabela = new DataTable();
                tabela.Load(citac);
                DataRow red;
                if (tabela.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    red = tabela.Rows[0];
                }
                return odo.napuni(red);
            }
            catch (Exception)
            {

                throw new Exception("Greska u radu sa bazom.");
            }
            finally
            {
                if (citac != null)
                {
                    citac.Close();
                }
            }
        }
        public int izmeni(OpstiDomenskiObjekat odo)
        {
            string upit = "UPDATE " + odo.tabela + " SET " + odo.azuriranje + " WHERE " + odo.uslovJedan;
            komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw new Exception("Greska u radu sa bazom.");
            }
        }
        public int sacuvaj(OpstiDomenskiObjekat odo)
        {
            string upit = "INSERT INTO " + odo.tabela + " " + odo.upisivanje;
            komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw new Exception("Greska u radu sa bazom.");
            }
        }
        public int obrisi(OpstiDomenskiObjekat odo)
        {
            string upit = "DELETE * FROM " + odo.tabela + " WHERE " + odo.uslovJedan;
            komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw new Exception("Greska u radu sa bazom.");
            }
        }
        public int obrisiZaUslovVise(OpstiDomenskiObjekat odo)
        {
            string upit = "DELETE * FROM " + odo.tabela + " WHERE " + odo.uslovVise;
            komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                return komanda.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw new Exception("Greska u radu sa bazom.");
            }
        }
        public int vratiSifru(OpstiDomenskiObjekat odo)
        {
            string upit = "SELECT MAX(" + odo.kljuc + ") FROM " + odo.tabela;
            komanda = new OleDbCommand(upit, konekcija, transakcija);
            try
            {
                try
                {
                    int sifra = Convert.ToInt32(komanda.ExecuteScalar());
                    return sifra + 1;

                }
                catch (Exception)
                {

                    return 1;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

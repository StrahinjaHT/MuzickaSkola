using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komunikacija;
using Biblioteka;
using System.Windows.Forms;
using System.ComponentModel;

namespace KontrolerKorisnickogInterfejsa
{
    public class KontrolerKI
    {
        public static Komunikacija.Komunikacija komunikacija;

        public static Ucenik ucenik;

        public static Profesor profesor;

        public static Predavanje predavanje;

        public static Radnik radnik;

        public static bool poveziSeNaServer()
        {
            komunikacija = new Komunikacija.Komunikacija();
            
            return komunikacija.poveziSeNaServer();
            
        }

        public void popuniPoljaPredavanje(TextBox txtSifra, ComboBox cmbPredmet, ComboBox cmbProfesor, TextBox txtDatum, TextBox txtOd, TextBox txtDo, ListBox listUcenici)
        {
            try
            {
                txtSifra.Text = predavanje.PredavanjeID.ToString();
                cmbPredmet.DataSource = vratiSvePredmete();
                cmbPredmet.SelectedItem = predavanje.Predmet as Predmet;
                cmbProfesor.DataSource = vratiSveProfesore();
                cmbProfesor.SelectedItem = predavanje.Profesor as Profesor;


                profesor = cmbProfesor.SelectedItem as Profesor; ;
                profesor = komunikacija.pronadjiProfesora(profesor);


               
                txtDatum.Text = predavanje.DatumPredavanja.ToShortDateString();
                txtOd.Text = predavanje.PocetakPredavanja.ToShortTimeString();
                txtDo.Text = predavanje.KrajPredavanja.ToShortTimeString();

                List<Ucenik> lista = new List<Ucenik>();
                foreach (Prisustvuje p in predavanje.ListaUcenika)
                {
                    Ucenik ucenik = new Ucenik();
                    ucenik = p.Ucenik;
                    foreach (Ucenik uc in vratiSveUcenike())
                    {
                        if (ucenik.JmbgUcenika == uc.JmbgUcenika)
                        {
                            ucenik = uc;
                        }
                    }
                    lista.Add(ucenik);
                }
                listUcenici.DataSource = lista;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void popuniPoljaProfesor(TextBox txtJMBG, TextBox txtIme, TextBox txtPrezime, TextBox txtTelefon, ListBox listPredmeti)
        {
            try
            {
                txtJMBG.Text = profesor.JmbgProfesora;
                txtIme.Text = profesor.ImeProfesora;
                txtPrezime.Text = profesor.PrezimeProfesora;
                txtTelefon.Text = profesor.Telefon;
                //         List<Predmet> lp = komunikacija.vratiSvePredmete();
                List<Predmet> lista = new List<Predmet>();
                foreach (Predaje p in profesor.ListaPredmeta)
                {
                    Predmet predmet = new Predmet();
                    predmet = p.Predmet;
                    foreach (Predmet pred in vratiSvePredmete())
                    {
                        if (predmet.PredmetID == pred.PredmetID)
                        {
                            predmet.NazivPredmeta = pred.NazivPredmeta;
                        }
                    }
                    lista.Add(predmet);
                }
                listPredmeti.DataSource = lista;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<Predmet> popuniPredmete(ComboBox cmbProfesor)
        {
            profesor = cmbProfesor.SelectedItem as Profesor;
            profesor = komunikacija.pronadjiProfesora(profesor);
            // cmbProfesor.SelectedItem = predavanje.Profesor as Profesor;
            List<Predmet> listaPredmeta = new List<Predmet>();

            
            foreach (Predaje pred in profesor.ListaPredmeta)
            {
                
                    listaPredmeta.Add(pred.Predmet);
                

            }
            return listaPredmeta;
        }

        public bool pronadjiPredavanje(DataGridView dataGridView1)
        {
            try
            {
                predavanje = dataGridView1.CurrentRow.DataBoundItem as Predavanje;
                predavanje = komunikacija.pronadjiPredavanje(predavanje);

                if (predavanje == null)
                {
                    MessageBox.Show("Sistem ne moze da ucita predavanje.");
                    return false;
                }
                else
                {
                    MessageBox.Show("Sistem je ucitao predavanje.");
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public bool pronadjiProfesora(DataGridView dataGridView1)
        {
            try
            {
                profesor = dataGridView1.CurrentRow.DataBoundItem as Profesor;
                profesor = komunikacija.pronadjiProfesora(profesor);
                
                if (profesor == null)
                {
                    MessageBox.Show("Sistem ne moze da ucita profesora.");
                    return false;
                }
                else
                {
                    MessageBox.Show("Sistem je ucitao profesora.");
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
                //MessageBox.Show("Nije odabran profesor.");
                //return false;
            }
        }

        public string dobrodoslica()
        {
            return "Dobrodosao/la, " + radnik.ToString();
        }

        public bool pronadjiRadnika(TextBox txtIme, TextBox txtLozinka)
        {
            try
            {
                radnik = new Radnik();
                radnik.KorisnickoIme = txtIme.Text;
                radnik.Lozinka = txtLozinka.Text;

                radnik = komunikacija.pronadjiRadnika(radnik);
                if (radnik == null)
                {
                    MessageBox.Show("Pogresno ime ili lozinka.");
                    return false;
                }
                else
                {
                    MessageBox.Show("Uspesno prijavljivanje.");
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void pronadjiPredavanja(TextBox txtDatum, DataGridView dataGridView1)
        {

            try
            {
                predavanje = new Predavanje();
                try
                {
                    predavanje.DatumPredavanja = DateTime.ParseExact(txtDatum.Text, "dd.MM.yyyy", null);
                }
                catch (Exception)
                {

                    MessageBox.Show("Neispravan datum.");
                    return;
                }

                List<Predavanje> lista = komunikacija.pronadjiPredavanja(predavanje);



                if (lista == null || lista.Count == 0)
                {
                    MessageBox.Show("Nema predavanja tog datuma.");
                }
                else
                {
                    // MessageBox.Show("Sistem je pronasao predavanja.");
                }

                foreach (Predavanje p in lista)
                {
                    foreach (Profesor pr in komunikacija.vratiSveProfesore())
                    {
                        if (p.Profesor.JmbgProfesora == pr.JmbgProfesora) p.Profesor = pr;
                    }
                    foreach (Predmet pr in komunikacija.vratiSvePredmete())
                    {
                        if (p.Predmet.PredmetID == pr.PredmetID) p.Predmet = pr;
                    }


                }
                dataGridView1.DataSource = lista;
                dataGridView1.Columns["PocetakPredavanja"].DefaultCellStyle.Format = "HH:mm";
                dataGridView1.Columns["KrajPredavanja"].DefaultCellStyle.Format = "HH:mm";
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public bool obrisiPredavanje()
        {
            try
            {
                
                object o = komunikacija.obrisiPredavanje(predavanje);
                if (o == null)
                {
                    MessageBox.Show("Sistem ne moze da obrise predavanje.");
                    return false;
                }
                else
                {
                    MessageBox.Show("Sistem je obrisao predavanje.");
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void popuniPoljaUcenik(TextBox txtJMBG, TextBox txtIme, TextBox txtPrezime, TextBox txtTelefon, TextBox txtGodina, ComboBox cmbOdsek)
        {
            try
            {
                txtJMBG.Text = ucenik.JmbgUcenika;
                txtIme.Text = ucenik.ImeUcenika;
                txtPrezime.Text = ucenik.PrezimeUcenika;
                txtTelefon.Text = ucenik.Telefon;
                txtGodina.Text = ucenik.Godina.ToString();
                cmbOdsek.DataSource = vratiSveOdseke();
                cmbOdsek.SelectedItem = ucenik.Odsek as Odsek;
            }
            catch (Exception)
            {

                throw;
            }
  
        }
        //
        public bool zapamtiPredavanje(TextBox txtDatum, TextBox txtOd, TextBox txtDo, ComboBox cmbPredmet, ComboBox cmbProfesor, ListBox listUcenici)
        {

            try
            {
                try
                {
                    predavanje.DatumPredavanja = DateTime.ParseExact(txtDatum.Text, "dd.MM.yyyy", null);
                }
                catch (Exception)
                {

                    MessageBox.Show("Neispravan datum.");
                    txtDatum.Focus();
                    return false;
                }
                try
                {
                    predavanje.PocetakPredavanja = DateTime.ParseExact(txtOd.Text, "HH:mm", null);
                    predavanje.KrajPredavanja = DateTime.ParseExact(txtDo.Text, "H:mm", null);
                }
                catch (Exception)
                {

                    MessageBox.Show("Neispravno vreme.");
                    txtOd.Focus();
                    txtDo.Focus();
                    return false;
                }
                if (predavanje.PocetakPredavanja == null || predavanje.KrajPredavanja == null)
                {
                    MessageBox.Show("Niste dobro uneli vreme predavanja.");
                    return false;
                }
                predavanje.Predmet = cmbPredmet.SelectedItem as Predmet;
                predavanje.Profesor = cmbProfesor.SelectedItem as Profesor;
                bool i=false;
                foreach (Predaje pred in predavanje.Profesor.ListaPredmeta)
                {
                    if (pred.Predmet.PredmetID == predavanje.Predmet.PredmetID)
                    {
                        i = true;
                    }

                }
                if(!i)
                {
                    MessageBox.Show("Profesor ne predaje taj predmet.");
                    return false;
                }
                foreach (Ucenik u in listUcenici.SelectedItems)
                {
                    Prisustvuje p = new Prisustvuje();
                    p.Ucenik = u;
                    p.Predavanje = predavanje;

                    predavanje.ListaUcenika.Add(p);
                }

                Object o = komunikacija.zapamtiPredavanje(predavanje);
                if (o == null)
                {
                    MessageBox.Show("Sistem ne moze da sacuva predavanje.");
                    return false;
                }
                else
                {
                    MessageBox.Show("Sistem je sacuvao predavanje.");
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void kreirajPredavanje(TextBox txtSifra,  GroupBox groupBox1)
        {

            try
            {
                predavanje = komunikacija.kreirajPredavanje();
                if (predavanje == null)
                {
                    MessageBox.Show("Sistem ne moze da kreira predavanje.");
                }
                else
                {
                    MessageBox.Show("Sistem je kreirao predavanje.");
                    txtSifra.Text = predavanje.PredavanjeID.ToString();
                    groupBox1.Enabled = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void pronadjiProfesore(TextBox txtPrezime, DataGridView dataGridView1)
        {
            try
            {
                profesor = new Profesor();
                profesor.PrezimeProfesora = txtPrezime.Text;

                List<Profesor> lista = komunikacija.pronadjiProfesore(profesor);



                if (lista == null || lista.Count == 0)
                {
                    MessageBox.Show("Ne postoje profesori za dato prezime.");
                }
                else
                {
                    // MessageBox.Show("Sistem je pronasao profesore.");
                }
                dataGridView1.DataSource = lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool sacuvajProfesora(TextBox txtJMBG, TextBox txtIme, TextBox txtPrezime, TextBox txtTelefon, ListBox listPredmeti)
        {
            try
            {
                profesor = new Profesor();
                try
                {
                    if (txtJMBG.Text.All(char.IsDigit))
                        profesor.JmbgProfesora = txtJMBG.Text;
                    else
                    {
                        MessageBox.Show("Neispravan JMBG.");
                        txtJMBG.Focus();
                        return false;
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Neispravan JMBG.");
                    txtJMBG.Focus();
                    return false;
                }
                profesor.ImeProfesora = txtIme.Text;
                profesor.PrezimeProfesora = txtPrezime.Text;
                if (profesor.ImeProfesora == "" || profesor.PrezimeProfesora == "")
                {
                    MessageBox.Show("Niste uneli ime i prezime.");
                    return false;
                }
                if (txtTelefon.Text.All(char.IsDigit))
                    profesor.Telefon = txtTelefon.Text;
                else
                {
                    MessageBox.Show("Neispravan telefon.");
                    txtTelefon.Focus();
                    return false;
                }


                foreach (Predmet p in listPredmeti.SelectedItems)
                {
                    Predaje pre = new Predaje();
                    pre.Predmet = p;
                    pre.Profesor = profesor;
                    profesor.ListaPredmeta.Add(pre);
                }

                Object o = komunikacija.sacuvajProfesora(profesor);
                if (o == null)
                {
                    MessageBox.Show("Sistem ne moze da sacuva profesora.");
                    return false;
                }
                else
                {
                    MessageBox.Show("Sistem je sacuvao profesora.");
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool obrisiUcenika()
        {
            try
            {
                Object o = komunikacija.obrisiUcenika(ucenik);
                if (o == null)
                {
                    MessageBox.Show("Sistem ne moze da obrise ucenika.");
                    return false;

                }
                else
                {
                    MessageBox.Show("Sistem je obrisao ucenika.");
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool pronadjiUcenika(DataGridView dataGridView1)
        {
            try
            {
                ucenik = dataGridView1.CurrentRow.DataBoundItem as Ucenik;
                ucenik = komunikacija.pronadjiUcenika(ucenik);
                if(ucenik==null)
                {
                    MessageBox.Show("Sistem ne moze da ucita ucenika.");
                    return false;
                }
                else
                {
                    MessageBox.Show("Sistem je ucitao ucenika.");
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void pronadjiUcenike(TextBox txtPrezime, DataGridView dataGridView1)
        {
            try
            {
                ucenik = new Ucenik();
                ucenik.PrezimeUcenika = txtPrezime.Text;

                List<Ucenik> lista = komunikacija.pronadjiUcenike(ucenik);



                if (lista == null || lista.Count == 0)
                {
                    MessageBox.Show("Ne postoje ucenici za dato prezime.");
                }
                else
                {
                    // MessageBox.Show("Sistem je pronasao clanove.");
                }
                dataGridView1.DataSource = lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void kraj()
        {
            komunikacija.kraj();
        }
        public List<Ucenik> vratiSveUcenike()
        {
            try
            {
                return komunikacija.vratiSveUcenike();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Predmet> vratiSvePredmete()
        {
            try
            {
                return komunikacija.vratiSvePredmete();
            }
            catch (Exception)
            {

                throw;
            }
        }
        // !!!
        public bool sacuvajUcenika(TextBox txtJMBG, TextBox txtIme, TextBox txtPrezime, TextBox txtTelefon, TextBox txtGodina, ComboBox cmbOdsek)
        {
            try
            {
                ucenik = new Ucenik();
                try
                {
                    if (txtJMBG.Text.All(char.IsDigit))
                        ucenik.JmbgUcenika = txtJMBG.Text;
                    else
                    {
                        MessageBox.Show("Neispravan JMBG.");
                        txtJMBG.Focus();
                        return false;
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Neispravan JMBG.");
                    txtJMBG.Focus();
                    return false;
                }
                ucenik.ImeUcenika = txtIme.Text;
                ucenik.PrezimeUcenika = txtPrezime.Text;
                if (ucenik.ImeUcenika == "" || ucenik.PrezimeUcenika == "")
                {
                    MessageBox.Show("Niste uneli ime i prezime.");
                    return false;
                }
                if (txtTelefon.Text.All(char.IsDigit))
                    ucenik.Telefon = txtTelefon.Text;
                else
                {
                    MessageBox.Show("Neispravan telefon.");
                    txtTelefon.Focus();
                    return false;
                }
                try
                {
                    ucenik.Godina = Convert.ToInt32(txtGodina.Text);
                    if(ucenik.Godina>6 || ucenik.Godina<1)
                    {
                        MessageBox.Show("Ne postoji ta godina.");
                        txtGodina.Focus();
                        return false;
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Godina mora da bude broj.");
                    txtGodina.Focus();
                    return false;
                }

                ucenik.Odsek = cmbOdsek.SelectedItem as Odsek;

                Object o = komunikacija.sacuvajUcenika(ucenik);
                if (o == null)
                {
                    MessageBox.Show("Sistem ne moze da sacuva ucenika.");
                    return false;
                }
                else
                {
                    MessageBox.Show("Sistem je sacuvao ucenika.");
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        public bool zapamtiUcenika(TextBox txtJMBG, TextBox txtIme, TextBox txtPrezime, TextBox txtTelefon, TextBox txtGodina, ComboBox cmbOdsek)
        {

            try
            {
                try
                {
                    if (txtJMBG.Text.All(char.IsDigit))
                        ucenik.JmbgUcenika = txtJMBG.Text;
                    else
                    {
                        MessageBox.Show("Neispravan JMBG.");
                        txtJMBG.Focus();
                        return false;
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Neispravan JMBG.");
                    txtJMBG.Focus();
                    return false;
                }
                ucenik.ImeUcenika = txtIme.Text;
                ucenik.PrezimeUcenika = txtPrezime.Text;
                if (ucenik.ImeUcenika == "" || ucenik.PrezimeUcenika == "")
                {
                    MessageBox.Show("Niste uneli ime i prezime.");
                    return false;
                }
                if (txtTelefon.Text.All(char.IsDigit))
                    ucenik.Telefon = txtTelefon.Text;
                else
                {
                    MessageBox.Show("Neispravan telefon.");
                    txtTelefon.Focus();
                    return false;
                }
                try
                {
                    ucenik.Godina = Convert.ToInt32(txtGodina.Text);
                    if (ucenik.Godina > 6 || ucenik.Godina < 1)
                    {
                        MessageBox.Show("Ne postoji ta godina.");
                        txtGodina.Focus();
                        return false;
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Godina mora da bude broj.");
                    txtGodina.Focus();
                    return false;
                }

                ucenik.Odsek = cmbOdsek.SelectedItem as Odsek;

                Object o = komunikacija.zapamtiUcenika(ucenik);
                if (o == null)
                {
                    MessageBox.Show("Sistem ne moze da zapamti ucenika.");
                    return false;
                }
                else
                {
                    MessageBox.Show("Sistem je zapamtio ucenika.");
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        public List<Odsek> vratiSveOdseke()
        {
            try
            {
                return komunikacija.vratiSveOdseke();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool obrisiProfesora()
        {
            try
            {
                
                object o = komunikacija.obrisiProfesora(profesor);
                if (o == null)
                {
                    MessageBox.Show("Sistem ne moze da obrise profesora.");
                    return false;
                }
                else
                {
                    MessageBox.Show("Sistem je obrisao profesora.");
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Profesor> vratiSveProfesore()
        {
            try
            {
                return komunikacija.vratiSveProfesore();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Predavanje> vratiSvaPredavanja(DataGridView dataGridView1)
        {
            try
            {
                List<Predavanje> lista = komunikacija.vratiSvaPredavanja();
                dataGridView1.DataSource = lista;
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void zatvoriGlavnuFormu()
        {
            try
            {
                if (Application.OpenForms["MeniForma"].IsAccessible) ;
                {
                    Form MeniForma = (Form)Application.OpenForms["MeniForma"];

                    MeniForma.Close();
                }
                
            }
            catch (Exception)
            {

                return;
            }
        }
    }
}

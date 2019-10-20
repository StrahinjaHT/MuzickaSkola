using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KontrolerKorisnickogInterfejsa;

namespace KorisnickiInterfejs
{
    public partial class UnosPredavanja : Form
    {
        private KontrolerKI kki;

        public UnosPredavanja(KontrolerKI kki)
        {
            InitializeComponent();
            this.kki = kki;
        }

        private void UnosPredavanja_Load(object sender, EventArgs e)
        {
            try
            {
                cmbProfesor.DataSource = kki.vratiSveProfesore();
                // cmbPredmet.DataSource = kki.popuniPredmete(cmbProfesor);
                cmbPredmet.DataSource = kki.vratiSvePredmete();
                listUcenici.DataSource = kki.vratiSveUcenike();
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                //  MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                kki.kreirajPredavanje(txtSifra, groupBox1);
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                //  MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
        }

        private void txtOd_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (kki.zapamtiPredavanje(txtDatum, txtOd, txtDo, cmbPredmet, cmbProfesor, listUcenici)) this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                //  MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
        }

        private void cmbPredmet_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

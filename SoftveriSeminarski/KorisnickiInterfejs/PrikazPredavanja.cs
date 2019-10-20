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
    public partial class PrikazPredavanja : Form
    {
        private KontrolerKI kki;


        public PrikazPredavanja(KontrolerKI kki)
        {
            InitializeComponent();
            this.kki = kki;
        }

        private void PrikazPredavanja_Load(object sender, EventArgs e)
        {
            try
            {
                kki.popuniPoljaPredavanje(txtSifra, cmbPredmet, cmbProfesor, txtDatum, txtOd, txtDo, listUcenici);
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                MeniForma.ActiveForm.Close();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (kki.obrisiPredavanje()) this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                MeniForma.ActiveForm.Close();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }
    }
}

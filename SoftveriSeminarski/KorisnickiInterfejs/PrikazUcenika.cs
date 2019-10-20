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
    public partial class PrikazUcenika : Form
    {
        private KontrolerKI kki;

        
        public PrikazUcenika(KontrolerKI kki)
        {
            InitializeComponent();
            this.kki = kki;
        }

        private void PrikazUcenika_Load(object sender, EventArgs e)
        {
            try
            {
                kki.popuniPoljaUcenik(txtJMBG, txtIme, txtPrezime, txtTelefon,txtGodina, cmbOdsek);
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                // MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (kki.zapamtiUcenika(txtJMBG, txtIme, txtPrezime, txtTelefon, txtGodina, cmbOdsek)) this.Close();
            }
            catch (Exception)
            {
                
                // MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (kki.obrisiUcenika()) this.Close();
            }
            catch (Exception)
            {
                
                //  MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
        }
    }
}

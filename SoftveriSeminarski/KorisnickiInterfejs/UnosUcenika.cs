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
    public partial class UnosUcenika : Form
    {
        private KontrolerKI kki;

        

        public UnosUcenika(KontrolerKI kki)
        {
            InitializeComponent();
            this.kki = kki;
        }

        private void UnosUcenika_Load(object sender, EventArgs e)
        {
            try
            {
                cmbOdsek.DataSource = kki.vratiSveOdseke();
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");

                //   MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (kki.sacuvajUcenika(txtJMBG, txtIme, txtPrezime, txtTelefon, txtGodina, cmbOdsek)) this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                // MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
        }
    }
}

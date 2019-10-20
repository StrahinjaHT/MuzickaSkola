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
    public partial class PrikazProfesora : Form
    {
        private KontrolerKI kki;


        public PrikazProfesora(KontrolerKI kki)
        {
            InitializeComponent();
            this.kki = kki;
        }

        private void PrikazProfesora_Load(object sender, EventArgs e)
        {
            try
            {
                kki.popuniPoljaProfesor(txtJMBG, txtIme, txtPrezime, txtTelefon, listPredmeti);
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                //  MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (kki.obrisiProfesora()) this.Close();
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

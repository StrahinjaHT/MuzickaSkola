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
    public partial class PretrazivanjeProfesora : Form
    {
        private KontrolerKI kki;


        public PretrazivanjeProfesora(KontrolerKI kki)
        {
            InitializeComponent();
            this.kki = kki;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (kki.pronadjiProfesora(dataGridView1)) new PrikazProfesora(kki).ShowDialog();
                txtPrezime_TextChanged_1(sender, e);
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                //  MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
            //  if (kki.obrisiProfesora(dataGridView1)) this.Close();
        }

        private void txtPrezime_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void PretrazivanjeProfesora_Load(object sender, EventArgs e)
        {
            try
            {
                kki.pronadjiProfesore(txtPrezime, dataGridView1);
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                //  MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
        }

        private void txtPrezime_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                kki.pronadjiProfesore(txtPrezime, dataGridView1);
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                //  MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
        }
    }
}

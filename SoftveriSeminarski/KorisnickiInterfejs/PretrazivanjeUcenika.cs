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
    public partial class PretrazivanjeUcenika : Form
    {
        private KontrolerKI kki;

        

        public PretrazivanjeUcenika(KontrolerKI kki)
        {
            InitializeComponent();
            this.kki = kki;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (kki.pronadjiUcenika(dataGridView1)) new PrikazUcenika(kki).ShowDialog();
                txtPrezime_TextChanged(sender, e);
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                // MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
        }

        private void txtPrezime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                kki.pronadjiUcenike(txtPrezime, dataGridView1);
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                // MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
        }

        private void PretrazivanjeUcenika_Load(object sender, EventArgs e)
        {
            try
            {
                kki.pronadjiUcenike(txtPrezime, dataGridView1);
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

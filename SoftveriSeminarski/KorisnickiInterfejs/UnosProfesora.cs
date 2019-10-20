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
    public partial class UnosProfesora : Form
    {
        private KontrolerKI kki;
        

        public UnosProfesora(KontrolerKI kki)
        {
            InitializeComponent();
            this.kki = kki;
        }

        private void UnosProfesora_Load(object sender, EventArgs e)
        {

            try
            {
                listPredmeti.DataSource = kki.vratiSvePredmete();
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                // MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (kki.sacuvajProfesora(txtJMBG, txtIme, txtPrezime, txtTelefon, listPredmeti)) this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Prekinuta konekcija.");
                //   MeniForma.ActiveForm.Close();
                kki.zatvoriGlavnuFormu();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class PretrazivanjePredavanja : Form
    {
        private KontrolerKI kki;

        public PretrazivanjePredavanja(KontrolerKI kki)
        {
            InitializeComponent();
            this.kki = kki;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                kki.pronadjiPredavanja(txtDatum, dataGridView1);
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
            
        }

        private void PretrazivanjePredavanja_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (kki.pronadjiPredavanje(dataGridView1)) new PrikazPredavanja(kki).ShowDialog();
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

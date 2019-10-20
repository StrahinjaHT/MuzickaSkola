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
    public partial class Login : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki;
        public Login()
        {
            InitializeComponent();
            kki = new KontrolerKI();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                KontrolerKI.poveziSeNaServer();
                if (kki.pronadjiRadnika(txtIme, txtLozinka)) new MeniForma().Show();
            }
            catch (Exception)
            {

                MessageBox.Show("Server nije pokrenut.");
            }
            
            
        }
    }
}

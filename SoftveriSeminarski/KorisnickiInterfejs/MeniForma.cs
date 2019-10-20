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
    public partial class MeniForma : Form
    {
        KontrolerKorisnickogInterfejsa.KontrolerKI kki;
        public MeniForma()
        {
            InitializeComponent();
            kki = new KontrolerKI();
         //   if(KontrolerKI.poveziSeNaServer()) this.Text="Klijent povezan"; 
        }

        private void MeniForma_Load(object sender, EventArgs e)
        {
            this.Text = kki.dobrodoslica();
        }

        private void MeniForma_FormClosed(object sender, FormClosedEventArgs e)
        {
           // kki.kraj();
        }

       

        private void unosNovogUcenikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UnosUcenika(kki).ShowDialog();
        }

        

        private void pretrazivanjeUcenikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PretrazivanjeUcenika(kki).ShowDialog();
        }

        private void unosNovogProfesoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UnosProfesora(kki).ShowDialog();
        }

        private void brisanjeProfesoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PretrazivanjeProfesora(kki).ShowDialog();
        }

        private void unosNovogPredavanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UnosPredavanja(kki).ShowDialog();
        }

        private void pretrazivanjePredavanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PretrazivanjePredavanja(kki).ShowDialog();
        }
        
    }
}

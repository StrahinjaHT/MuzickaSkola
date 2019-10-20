using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Ucenik : OpstiDomenskiObjekat
    {
        string jmbgUcenika;
        string imeUcenika;
        string prezimeUcenika;
        string telefon;
        int godina;
        Odsek odsek;
        BindingList<Prisustvuje> listaPrisustva;


        [Browsable(false)]
        public string tabela => "Ucenik";
        [Browsable(false)]
        public string kljuc => "JMBGUcenika";
        [Browsable(false)]
        public string uslovJedan => "JMBGUcenika='"+jmbgUcenika+"'";
        [Browsable(false)]
        public string uslovVise => "PrezimeUcenika like '"+prezimeUcenika+"%'";
        [Browsable(false)]
        public string azuriranje => "ImeUcenika='"+imeUcenika+"',PrezimeUcenika='"+prezimeUcenika+"'," +
            "Telefon='"+telefon+"',Godina="+godina+",OdsekID="+odsek.OdsekID;
        [Browsable(false)]
        public string upisivanje => "values('"+JmbgUcenika+"','"+imeUcenika+"','"+prezimeUcenika+"'," +
            "'"+telefon+"',"+godina+","+odsek.OdsekID+")";

        public string JmbgUcenika { get => jmbgUcenika; set => jmbgUcenika = value; }
        public string ImeUcenika { get => imeUcenika; set => imeUcenika = value; }
        public string PrezimeUcenika { get => prezimeUcenika; set => prezimeUcenika = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public int Godina { get => godina; set => godina = value; }
        
        public Odsek Odsek { get => odsek; set => odsek = value; }
        public BindingList<Prisustvuje> ListaPrisustva { get => listaPrisustva; set => listaPrisustva = value; }

        public override string ToString()
        {
            return imeUcenika+" "+prezimeUcenika;
        }
        public Ucenik()
        {
            ListaPrisustva = new BindingList<Prisustvuje>();
        }

        public OpstiDomenskiObjekat napuni(DataRow red)
        {
            Ucenik u = new Ucenik();
            u.jmbgUcenika = red[0].ToString();
            u.imeUcenika = red[1].ToString();
            u.PrezimeUcenika = red[2].ToString();
            u.telefon = red[3].ToString();
            u.godina = Convert.ToInt32(red[4]);
            u.odsek = new Odsek();
            u.odsek.OdsekID= Convert.ToInt32(red[5]);
            

            return u;
        }
    }
}

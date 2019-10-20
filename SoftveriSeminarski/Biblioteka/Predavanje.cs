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
    public class Predavanje : OpstiDomenskiObjekat
    {
        int predavanjeID;
        DateTime datumPredavanja;
        DateTime pocetakPredavanja;
        DateTime krajPredavanja;
        Profesor profesor;
        Predmet predmet;
        List<Prisustvuje> listaUcenika;

        [Browsable(false)]
        public string tabela => "Predavanje";
        [Browsable(false)]
        public string kljuc => "PredavanjeID";
        [Browsable(false)]
        public string uslovJedan => "PredavanjeID="+predavanjeID;
        [Browsable(false)]
        public string uslovVise => "Datum LIKE '" + datumPredavanja.ToShortDateString() + "'";
        [Browsable(false)]
        public string azuriranje => "Datum='"+datumPredavanja.ToShortDateString()+"',PocetakPredavanja='" + pocetakPredavanja.ToShortTimeString() + "',KrajPredavanja='" + krajPredavanja.ToShortTimeString() + "'," +
            "JMBGProfesora='" + profesor.JmbgProfesora + "',PredmetID=" + predmet.PredmetID;
        [Browsable(false)]
        public string upisivanje => "(PredavanjeID) values ("+predavanjeID+")";
        [Browsable(false)]
        public int PredavanjeID { get => predavanjeID; set => predavanjeID = value; }
        public DateTime DatumPredavanja { get => datumPredavanja; set => datumPredavanja = value; }
        
        public DateTime PocetakPredavanja { get => pocetakPredavanja; set => pocetakPredavanja = value; }

        public DateTime KrajPredavanja { get => krajPredavanja; set => krajPredavanja = value; }
        public Profesor Profesor { get => profesor; set => profesor = value; }
        public Predmet Predmet { get => predmet; set => predmet = value; }
        [Browsable(false)]
        public List<Prisustvuje> ListaUcenika { get => listaUcenika; set => listaUcenika = value; }
        

        public override string ToString()
        {
            return predmet.NazivPredmeta+"-"+pocetakPredavanja.ToShortDateString();
        }

        
        public Predavanje()
        {
            listaUcenika = new List<Prisustvuje>();
        }

        public OpstiDomenskiObjekat napuni(DataRow red)
        {
            Predavanje p = new Predavanje();
            p.predavanjeID= Convert.ToInt32(red[0]);
            p.datumPredavanja = Convert.ToDateTime(red[1]);
            p.pocetakPredavanja = Convert.ToDateTime(red[2]);
            p.krajPredavanja = Convert.ToDateTime(red[3]);
            p.profesor = new Profesor();
            p.predmet = new Predmet();
            p.profesor.JmbgProfesora = red[4].ToString();
            p.predmet.PredmetID = Convert.ToInt32(red[5]);


            return p;
        }
    }
}

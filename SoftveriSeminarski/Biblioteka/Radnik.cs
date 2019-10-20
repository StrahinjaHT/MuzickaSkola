using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Radnik : OpstiDomenskiObjekat
    {
        int radnikID;
        string korisnickoIme;
        string lozinka;
        string ime;
        string prezime;


        public string tabela => "Radnik";

        public string kljuc => "RadnikID";

        public string uslovJedan => "RadnikID="+radnikID;

        public string uslovVise => "KorisnickoIme='"+korisnickoIme+"' AND Lozinka='"+lozinka+"'";

        public string azuriranje => throw new NotImplementedException();

        public string upisivanje => throw new NotImplementedException();

        public int RadnikID { get => radnikID; set => radnikID = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }

        public override string ToString()
        {
            return ime+" "+prezime;
        }

        public OpstiDomenskiObjekat napuni(DataRow red)
        {
            Radnik r = new Radnik();
            r.radnikID = Convert.ToInt32(red[0]);
            r.korisnickoIme = red[1].ToString();
            r.lozinka = red[2].ToString();
            r.ime= red[3].ToString();
            r.prezime= red[4].ToString();
            return r;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Prisustvuje : OpstiDomenskiObjekat
    {
        Ucenik ucenik;
        Predavanje predavanje;

        public string tabela => "Prisustvuje";

        public string kljuc => null;

        public string uslovJedan => "JMBGUcenika= '" + Ucenik.JmbgUcenika + "'";

        public string uslovVise => "PredavanjeID= " + Predavanje.PredavanjeID;
            
        public string azuriranje => throw new NotImplementedException();

        public string upisivanje => "values ('" + Ucenik.JmbgUcenika + "'," + Predavanje.PredavanjeID + ")";

        public Ucenik Ucenik { get => ucenik; set => ucenik = value; }
        public Predavanje Predavanje { get => predavanje; set => predavanje = value; }

        public OpstiDomenskiObjekat napuni(DataRow red)
        {
            Prisustvuje p = new Prisustvuje();
            p.Ucenik = new Ucenik();
            p.Predavanje = new Predavanje();
            p.Ucenik.JmbgUcenika = red[0].ToString();
            p.Predavanje.PredavanjeID = Convert.ToInt32(red[1]);
            return p;
        }
    }
}

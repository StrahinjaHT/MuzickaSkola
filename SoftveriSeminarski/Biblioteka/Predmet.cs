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
    public class Predmet : OpstiDomenskiObjekat
    {
        int predmetID;
        string nazivPredmeta;
        BindingList<Predaje> listaProfesora;


        public string tabela => "Predmet";

        public string kljuc => "PredmetID";

        public string uslovJedan => "PredmetID="+predmetID;

        public string uslovVise => "NazivPredmeta like '"+nazivPredmeta+"%'";

        public string azuriranje => throw new NotImplementedException();

        public string upisivanje => throw new NotImplementedException();

        public int PredmetID { get => predmetID; set => predmetID = value; }
        public string NazivPredmeta { get => nazivPredmeta; set => nazivPredmeta = value; }
        public BindingList<Predaje> ListaProfesora { get => listaProfesora; set => listaProfesora = value; }


        public override string ToString()
        {
            return nazivPredmeta;
        }

        public override bool Equals(object obj)
        {
            if (obj is Predmet)
            {
                Predmet p = (Predmet)obj;
                if (p.predmetID == this.predmetID)
                {
                    return true;
                }
            }
            return false;
        }

        public Predmet()
        {
            listaProfesora = new BindingList<Predaje>();
        }

        public OpstiDomenskiObjekat napuni(DataRow red)
        {
            Predmet p = new Predmet();
            p.predmetID = Convert.ToInt32(red[0]);
            p.nazivPredmeta = red[1].ToString();
            return p;
        }
    }
}

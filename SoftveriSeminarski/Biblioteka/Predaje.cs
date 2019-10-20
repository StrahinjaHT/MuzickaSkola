using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Predaje : OpstiDomenskiObjekat
    {
        Profesor profesor;
        Predmet predmet;


        public string tabela => "Predaje";

        public string kljuc => null;

        public string uslovJedan => "JMBGProfesora= '" + Profesor.JmbgProfesora + "'";
            
        public string uslovVise => "PredmetID= " + Predmet.PredmetID;

        public string azuriranje => throw new NotImplementedException();

        public string upisivanje => "values ('"+Profesor.JmbgProfesora+"',"+Predmet.PredmetID+")";

        public Profesor Profesor { get => profesor; set => profesor = value; }
        public Predmet Predmet { get => predmet; set => predmet = value; }

        public OpstiDomenskiObjekat napuni(DataRow red)
        {
            Predaje p = new Predaje();
            p.Profesor = new Profesor();
            p.Predmet = new Predmet();
            p.Profesor.JmbgProfesora = red[0].ToString();
            p.Predmet.PredmetID = Convert.ToInt32(red[1]);

            return p;
        }
    }
}

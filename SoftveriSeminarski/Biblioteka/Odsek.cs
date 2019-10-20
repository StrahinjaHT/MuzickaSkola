using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Odsek : OpstiDomenskiObjekat
    {
        int odsekID;
        string nazivOdseka;
        int trajanje;


        public string tabela => "Odsek";

        public string kljuc => "OdsekID";

        public string uslovJedan => "OdsekID="+odsekID;

        public string uslovVise => null;

        public string azuriranje => throw new NotImplementedException();

        public string upisivanje => throw new NotImplementedException();

        public int OdsekID { get => odsekID; set => odsekID = value; }
        public string NazivOdseka { get => nazivOdseka; set => nazivOdseka = value; }
        public int Trajanje { get => trajanje; set => trajanje = value; }

        public override bool Equals(object obj)
        {
            if(obj is Odsek)
            {
                Odsek o = (Odsek)obj;
                if(o.odsekID == this.odsekID)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return nazivOdseka;
        }

        public OpstiDomenskiObjekat napuni(DataRow red)
        {
            Odsek o = new Odsek();
            o.odsekID = Convert.ToInt32(red[0]);
            o.nazivOdseka = red[1].ToString();
            o.trajanje = Convert.ToInt32(red[2]);
            return o;
        }
    }
}

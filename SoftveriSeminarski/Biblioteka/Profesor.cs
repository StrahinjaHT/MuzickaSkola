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
    public class Profesor : OpstiDomenskiObjekat
    {
        string jmbgProfesora;
        string imeProfesora;
        string prezimeProfesora;
        string telefon;
        List<Predaje> listaPredmeta;

        [Browsable(false)]
        public string tabela => "Profesor";
        [Browsable(false)]
        public string kljuc => "JMBGProfesora";
        //!!!
        [Browsable(false)]
        public string uslovJedan => "JMBGProfesora='"+jmbgProfesora+"'";
        //!!!
        [Browsable(false)]
        public string uslovVise => "PrezimeProfesora like '"+prezimeProfesora+"%'";
        [Browsable(false)]
        public string azuriranje => "ImeProfesora='" + imeProfesora + "',PrezimeProfesora='" + prezimeProfesora + "'," +
            "Telefon='" + telefon;
        [Browsable(false)]
        public string upisivanje => "values('" + JmbgProfesora + "','" + imeProfesora + "','" + prezimeProfesora + "','" +
              telefon +"')";

        public string JmbgProfesora { get => jmbgProfesora; set => jmbgProfesora = value; }
        public string ImeProfesora { get => imeProfesora; set => imeProfesora = value; }
        public string PrezimeProfesora { get => prezimeProfesora; set => prezimeProfesora = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public List<Predaje> ListaPredmeta { get => listaPredmeta; set => listaPredmeta = value; }

        public override string ToString()
        {
            return imeProfesora+" "+prezimeProfesora;
        }
        public Profesor()
        {
            listaPredmeta = new List<Predaje>();
        }
        public override bool Equals(object obj)
        {
            if (obj is Profesor)
            {
                Profesor p = (Profesor)obj;
                if (p.jmbgProfesora == this.jmbgProfesora)
                {
                    return true;
                }
            }
            return false;
        }

        public OpstiDomenskiObjekat napuni(DataRow red)
        {
            Profesor p = new Profesor();
            p.jmbgProfesora = red[0].ToString();
            p.imeProfesora = red[1].ToString();
            p.prezimeProfesora = red[2].ToString();
            p.Telefon = red[3].ToString();
            return p;
        }
    }
}

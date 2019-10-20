using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    public enum Operacije { Kraj=1,
        PronadjiUcenika = 2,
        VratiSveUcenike = 3,
        VratiSveOdseke = 4,
        ObrisiUcenika = 5,
        ZapamtiUcenika = 6,
        SacuvajUcenika = 7,
        PronadjiUcenike = 8,
        SacuvajProfesora = 9,
        VratiSvePredmete = 10,
        PronadjiProfesore = 11,
        PronadjiProfesora = 12,
        ObrisiProfesora = 13,
        KreirajPredavanje = 14,
        ZapamtiPredavanje = 15,
        PronadjiPredavanja = 16,
        VratiSveProfesore = 17,
        ObrisiPredavanje = 18,
        PronadjiRadnika = 19,
        VratiSvaPredavanja = 20,
        PronadjiPredavanje = 21
    }
    [Serializable]
    public class TransferKlasa
    {
        Operacije operacija;
        Object transferObjekat;
        Object rezultat;
        
        public object TransferObjekat { get => transferObjekat; set => transferObjekat = value; }
        public Operacije Operacija { get => operacija; set => operacija = value; }
        public object Rezultat { get => rezultat; set => rezultat = value; }
    }
}

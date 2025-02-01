using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Models.Walidator
{
    public  class StringWalidator : Walidator
    {
        public static string SprawdzCzyZaczynaSieOdDuzejLitery(string tekst)
        {
            try
            {
                if(!char.IsUpper(tekst,0))
                    return "Pierwsza litera musi być duża";

            }
            catch (Exception e)
            {
                
            }
            return null;
        }
        public static string SprawdzOpis(string opis)
        {
            if (string.IsNullOrWhiteSpace(opis))
                return "Opis nie może być pusty";

            var words = opis.Split(' ');
            if (words.Length < 5)
                return "Opis musi zawierać minimum 4 ";

            return null;
        }
        public static string SprawdzUnikalnoscNazwyProjektu(string nazwaProjektu, ZarzadanieProjektami2Entities db)
        {
            var projekt = (from b in db.Projekty
                           where b.nazwa == nazwaProjektu
                           select b).FirstOrDefault();

            if (projekt != null)
                return "Nazwa projektu musi być unikalna";

            return null;
        }
        public static string SprawdzCzyNieJestPusty(string tekst)
        {
            if (string.IsNullOrWhiteSpace(tekst))
                return "Pole nie może być puste";

            return null;
        }
    }
}

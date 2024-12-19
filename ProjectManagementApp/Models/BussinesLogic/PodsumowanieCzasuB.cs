using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Models.BussinesLogic
{
     public class PodsumowanieCzasuB : DateBaseClass
    {
        #region Konstutkor

        public PodsumowanieCzasuB(ZarzadanieProjektami2Entities db): base(db) { 
        
        }
        #endregion
        #region FunkcjaBiznesowa
        public decimal? CalkowityCzas(int idProjektu)
        {
            return (
                from czas in db.RejestrCzasuPracyProjekt
                where czas.projekt_id == idProjektu
                select czas.czas_spedzony
            ).Sum();
        }

        //Przyszlocciwoe dodoanie do bazy
        public decimal? CalkowityCzasReturnVariable(int idProjektu)
        {
            var sumaCzasu = (
                from czas in db.RejestrCzasuPracyProjekt
                where czas.projekt_id == idProjektu
                select czas.czas_spedzony
            ).Sum();

            var podsumowanie = (from p in db.PodsumowanieCzasu
                                where p.projekt_id == idProjektu
                                select p).FirstOrDefault();
            if (podsumowanie != null)
            {
                // Aktualizacja istniejącego rekordu
                podsumowanie.calkowity_czas = sumaCzasu;
            }
            else
            {
                // Dodanie nowego rekordu
                db.PodsumowanieCzasu.Add(new PodsumowanieCzasu
                {
                    projekt_id = idProjektu,
                    calkowity_czas = sumaCzasu
                });
            }


            db.SaveChanges();
            return (
                 from czas in db.PodsumowanieCzasu
                 where czas.projekt_id == idProjektu
                 select czas.calkowity_czas 
             ).Sum();
        }
        #endregion
    }
}

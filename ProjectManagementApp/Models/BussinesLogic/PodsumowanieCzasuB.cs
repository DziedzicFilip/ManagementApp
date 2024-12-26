using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

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
        public  void SprawdzPodsumowanie(int idProjektu)
        {

            var sumaCzasu = (
               from czas in db.RejestrCzasuPracyProjekt
               where czas.projekt_id == idProjektu
               select czas.czas_spedzony
           ).Sum();

            var podsumowanie = (from p in db.PodsumowanieCzasu
                                where p.projekt_id == idProjektu
                                select p).FirstOrDefault();

            var Projekt = (from p in db.Projekty
                           where p.projekt_id == idProjektu
                           select p).FirstOrDefault();
            if (podsumowanie != null)
            {
                
                podsumowanie.calkowity_czas = sumaCzasu;
            }
            else
            {
                
                db.PodsumowanieCzasu.Add(new PodsumowanieCzasu
                {
                    projekt_id = idProjektu,
                    calkowity_czas = sumaCzasu,
                    data_rozpoczecia = Projekt.data_rozpoczecia,
                    data_zakonczenia = Projekt.data_zakonczenia
                });
            }


            db.SaveChanges();
        }

       
        public decimal? CalkowityCzasReturnVariable(int idProjektu)
        {
           SprawdzPodsumowanie(idProjektu);
            return (
                 from czas in db.PodsumowanieCzasu
                 where czas.projekt_id == idProjektu
                 select czas.calkowity_czas 
             ).Sum();
        }
        public List<RejestrCzasuPracyProjekt> PobierzDaneRejestrCzasu(int idProjektu)
        {
            return (
                from czas in db.RejestrCzasuPracyProjekt
                where czas.projekt_id == idProjektu
                select czas
            ).ToList();
        }

        #endregion
    }
}

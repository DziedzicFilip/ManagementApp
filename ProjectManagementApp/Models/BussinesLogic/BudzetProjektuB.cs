using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Models.BussinesLogic
{
    public class BudzetProjektuB : DateBaseClass
    {
        #region Konstruktor
        public BudzetProjektuB(ZarzadanieProjektami2Entities db) : base(db) { }
        #endregion
        #region FunkcjaBiznoeswa
        public decimal? BudzetProjektuKal(int idProjektu, decimal wydanaKwota)
        {
            // Pobieranie rekordu budżetu dla danego projektu
            var budzet = (from b in db.BudzetProjektu
                          where b.projekt_id == idProjektu
                          select b).FirstOrDefault();

           
                
       
                
                    // Aktualizacja wartości pozostałej kwoty (odjęcie wydanej kwoty)
                    budzet.pozostala_kwota -= wydanaKwota;

                    // Aktualizacja wartości wydanej kwoty (dodanie nowej kwoty)
                    budzet.wydana_kwota += wydanaKwota;

                    // Zapisanie zmian w bazie danych
                    db.SaveChanges();

                    // Zwracamy nową wartość pozostałej kwoty
                    return budzet.pozostala_kwota;
                
              
        }
        public decimal? WyswietlCalkowityBudzet(int idProjektu)
        {
            // Pobierz całkowity budżet projektu
            return  (from b in db.BudzetProjektu
                                   where b.projekt_id == idProjektu
                                   select b.calkowity_budzet).FirstOrDefault();

           
        }
        public decimal? WyswietlWydanaKwote(int idProjektu)
        {
            // Pobierz wydaną kwotę projektu
             return  (from b in db.BudzetProjektu
                               where b.projekt_id == idProjektu
                               select b.wydana_kwota).Sum();

           
        }

        #endregion
    }
}

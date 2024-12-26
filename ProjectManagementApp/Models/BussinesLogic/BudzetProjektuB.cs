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
         
            var budzet = (from b in db.BudzetProjektu
                          where b.projekt_id == idProjektu
                          select b).FirstOrDefault();    
                    budzet.pozostala_kwota -= wydanaKwota;        
                    budzet.wydana_kwota += wydanaKwota;
                    db.SaveChanges();
                    return budzet.pozostala_kwota;
                
              
        }
        public decimal? WyswietlCalkowityBudzet(int idProjektu)
        {
            
            return  (from b in db.BudzetProjektu
                                   where b.projekt_id == idProjektu
                                   select b.calkowity_budzet).Sum();

           
        }
        public decimal? WyswietlWydanaKwote(int idProjektu)
        {
            
             return  (from b in db.BudzetProjektu
                               where b.projekt_id == idProjektu
                               select b.wydana_kwota).Sum();

           
        }
        public decimal? WyswietlPozostalaKwota(int idProjektu)
        {
           
            return (from b in db.BudzetProjektu
                    where b.projekt_id == idProjektu
                    select b.pozostala_kwota).Sum();


        }

        #endregion
    }
}

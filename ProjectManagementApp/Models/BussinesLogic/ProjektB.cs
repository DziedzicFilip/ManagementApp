using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Models.BussinesLogic
{
    public  class ProjektB : DateBaseClass
    {
        #region Konstruktor
         public ProjektB(ZarzadanieProjektami2Entities db):base(db) { 
        
        }
        #endregion
        #region FunckjaBiznesowa
        public IQueryable<KeyAndValue> GetProjektyKeyAndValue()
        {
            return
                (
                from Projekty in db.Projekty
                select new KeyAndValue
                {
                    Key= Projekty.projekt_id,
                    Value = Projekty.nazwa, 
                }
                ).ToList().AsQueryable();
        }

       public BudzetProjektu existingBudget(int ? id)
        {
           
            return (from b in db.BudzetProjektu
                    where b.projekt_id == id
                    select b).FirstOrDefault(); 
        }

        public HistoriaDzialanProjektu existingHistoriaDzialanProjektu(int? id)
        {
            return (from h in db.HistoriaDzialanProjektu
                    where h.projekt_id == id
                    select h).FirstOrDefault();
        }

        public NotatkiProjekty existingNotatkiProjekty(int? id)
        {
            return (from n in db.NotatkiProjekty
                    where n.projekt_id == id
                    select n).FirstOrDefault();
        }

        public PlikiProjekty existingPlikiProjekty(int? id)
        {
            return (from p in db.PlikiProjekty
                    where p.projekt_id == id
                    select p).FirstOrDefault();
        }

        public PodsumowanieCzasu existingPodsumowanieCzasu(int? id)
        {
            return (from pc in db.PodsumowanieCzasu
                    where pc.projekt_id == id
                    select pc).FirstOrDefault();
        }

        public RejestrCzasuPracyProjekt existingRejestrCzasuPracyProjekt(int? id)
        {
            return (from r in db.RejestrCzasuPracyProjekt
                    where r.projekt_id == id
                    select r).FirstOrDefault();
        }

        public RyzykaProjektu existingRyzykaProjektu(int? id)
        {
            return (from ry in db.RyzykaProjektu
                    where ry.projekt_id == id
                    select ry).FirstOrDefault();
        }

        public Zadania existingZadania(int? id)
        {
            return (from z in db.Zadania
                    where z.projekt_id == id
                    select z).FirstOrDefault();
        }

        public Tagi existingTagi(int? id)
        {
            return (from t in db.Tagi
                    where t.Projekty.Any(p => p.projekt_id == id)
                    select t).FirstOrDefault();
        }

        


        #endregion
    }
}

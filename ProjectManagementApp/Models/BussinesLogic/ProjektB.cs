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


        #endregion
    }
}

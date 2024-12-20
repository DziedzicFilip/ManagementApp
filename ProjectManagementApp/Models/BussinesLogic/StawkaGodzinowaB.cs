using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Models.BussinesLogic
{
    public class StawkaGodzinowaB : PodsumowanieCzasuB
    {
        #region  Konstuktor
        public StawkaGodzinowaB(ZarzadanieProjektami2Entities db) : base(db) { }
        #endregion
        #region FunckcjaBiznesowa
        public decimal? Stawka(int idProjektu,decimal StawkaNaGodzine)
        {

            SprawdzPodsumowanie(idProjektu);

            return (

                 from PodsumowanieCzasu in db.PodsumowanieCzasu
                 where PodsumowanieCzasu.projekt_id == idProjektu
                 select PodsumowanieCzasu.calkowity_czas * StawkaNaGodzine

                ).Sum();
        }
        #endregion


    }
}

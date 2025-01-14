using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;

namespace ProjectManagementApp.Models.BussinesLogic
{
    public class StawkaGodzinowaB : PodsumowanieCzasuB
    {
        #region  Konstruktor
        public StawkaGodzinowaB(ZarzadanieProjektami2Entities db) : base(db) { }
        #endregion

        #region FunkcjaBiznesowa
        public decimal Rabat(int dniOpoznienia, int  idProjektu, decimal stawkaNaGodzine) 
        {
            return dniOpoznienia * 1.05m * stawkaNaGodzine;
        }
        public decimal? Stawka(int idProjektu, decimal stawkaNaGodzine, string waluta)
        {
            SprawdzPodsumowanie(idProjektu);
            int dniOpoznienia = ObliczDniOpoznienia(idProjektu);
            decimal rabat = Rabat(dniOpoznienia, idProjektu, stawkaNaGodzine);
            decimal? calkowityCzas = (from PodsumowanieCzasu in db.PodsumowanieCzasu
                                      where PodsumowanieCzasu.projekt_id == idProjektu
                                      select PodsumowanieCzasu.calkowity_czas).Sum();

            decimal? stawka = calkowityCzas * stawkaNaGodzine;
            if (dniOpoznienia > 0)
            {
                stawka -= rabat;
            }

           
            return stawka;
        }
        public decimal? Stawka(int idProjektu, decimal StawkaNaGodzine)
        {

            SprawdzPodsumowanie(idProjektu);
            int dniOpoznienia = ObliczDniOpoznienia(idProjektu);
            decimal rabat = dniOpoznienia * 0.05m * StawkaNaGodzine;

            return (

                 from PodsumowanieCzasu in db.PodsumowanieCzasu
                 where PodsumowanieCzasu.projekt_id == idProjektu
                 select PodsumowanieCzasu.calkowity_czas * StawkaNaGodzine

                ).Sum();

        }
        #endregion
    }
}

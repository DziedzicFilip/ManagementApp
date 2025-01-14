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
            return (

                 from PodsumowanieCzasu in db.PodsumowanieCzasu
                 where PodsumowanieCzasu.projekt_id == idProjektu
                 select PodsumowanieCzasu.calkowity_czas * StawkaNaGodzine

                ).Sum();

        }

        public (decimal? WartoscBruttoPLN, decimal? WartoscNettoPLN, decimal? WartoscBruttoEUR, decimal? WartoscNettoEUR, decimal? WartoscPLNBezRabatu, decimal? WartoscEuroBezRabatu) 
        ObliczWartosci(int idProjektu, decimal stawkaGodzinowa, string wybranaWaluta, string wybranyTypUmowy)
        {
            decimal kursEuroNaPln = 4.5m;
            decimal VatRate = 0.23m;

            switch (wybranyTypUmowy)
            {
                case "Dzieło":
                case "Zlecenie":
                    VatRate = 0m;
                    break;
                case "B2B":
                    VatRate = 0.23m;
                    break;
            }

            decimal? wartoscBruttoPLN = null;
            decimal? wartoscNettoPLN = null;
            decimal? wartoscBruttoEUR = null;
            decimal? wartoscNettoEUR = null;
            decimal? wartoscPLNBezRabatu = null;
            decimal? wartoscEuroBezRabatu = null;

            if (wybranaWaluta == "PLN")
            {
                wartoscBruttoPLN = Math.Round((Stawka(idProjektu, stawkaGodzinowa, "PLN") ?? 0), 2);
                wartoscNettoPLN = Math.Round((wartoscBruttoPLN.GetValueOrDefault() * (1 - VatRate)), 2);
                wartoscBruttoEUR = Math.Round((wartoscBruttoPLN.GetValueOrDefault() / kursEuroNaPln), 2);
                wartoscNettoEUR = Math.Round((wartoscBruttoEUR.GetValueOrDefault() * (1 - VatRate)), 2);
                wartoscPLNBezRabatu = Math.Round((Stawka(idProjektu, stawkaGodzinowa) ?? 0), 2);
                wartoscEuroBezRabatu = Math.Round((wartoscPLNBezRabatu.GetValueOrDefault() / kursEuroNaPln), 2);
            }
            else
            {
                wartoscBruttoEUR = Math.Round((Stawka(idProjektu, stawkaGodzinowa, "EURO") ?? 0), 2);
                wartoscNettoEUR = Math.Round((wartoscBruttoEUR.GetValueOrDefault() * (1 - VatRate)), 2);
                wartoscEuroBezRabatu = Math.Round((Stawka(idProjektu, stawkaGodzinowa) ?? 0), 2);
                wartoscPLNBezRabatu = Math.Round((wartoscEuroBezRabatu.GetValueOrDefault() * kursEuroNaPln), 2);
                wartoscBruttoPLN = Math.Round((wartoscBruttoEUR.GetValueOrDefault() * kursEuroNaPln), 2);
                wartoscNettoPLN = Math.Round((wartoscBruttoPLN.GetValueOrDefault() * (1 - VatRate)), 2);
            }

            return (wartoscBruttoPLN, wartoscNettoPLN, wartoscBruttoEUR, wartoscNettoEUR, wartoscPLNBezRabatu, wartoscEuroBezRabatu);
        }
        #endregion
    }
}

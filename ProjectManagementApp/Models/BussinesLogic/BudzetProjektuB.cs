using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectManagementApp.Models.BussinesLogic
{
    public class BudzetProjektuB : DateBaseClass
    {
        #region Konstruktor
        public BudzetProjektuB(ZarzadanieProjektami2Entities db) : base(db) { }
        #endregion
        #region FunkcjaBiznoeswa
        public void BudzetProjektuKal(int idProjektu, decimal wydanaKwota,string Waluta)
        {

            var budzet = (from b in db.BudzetProjektu
                          where b.projekt_id == idProjektu
                          select b).FirstOrDefault();
            if(Waluta=="Euro")
            {
                wydanaKwota *= 4.5m;
                wydanaKwota = Math.Round(wydanaKwota, 2);
            }
            if(budzet.pozostala_kwota == null)
            {
                budzet.pozostala_kwota = budzet.calkowity_budzet;
            }
            if(budzet.wydana_kwota == null)
            {
                budzet.wydana_kwota = 0;
            }
            budzet.pozostala_kwota -= wydanaKwota;
            budzet.wydana_kwota += wydanaKwota;
            db.SaveChanges();
           


        }
        public decimal? WyswietlCalkowityBudzet(int idProjektu)
        {

            return (from b in db.BudzetProjektu
                    where b.projekt_id == idProjektu
                    select b.calkowity_budzet).Sum();


        }
        public decimal? WyswietlWydanaKwote(int idProjektu)
        {

            return (from b in db.BudzetProjektu
                    where b.projekt_id == idProjektu
                    select b.wydana_kwota).Sum();


        }
        public decimal? WyswietlPozostalaKwota(int idProjektu)
        {

            return (from b in db.BudzetProjektu
                    where b.projekt_id == idProjektu
                    select b.pozostala_kwota).Sum();


        }

        public decimal? DodajDoBudzetu(int idProjektu, decimal dodanaKwota,string Waluta)
        {
            var budzet = (from b in db.BudzetProjektu
                          where b.projekt_id == idProjektu
                          select b).FirstOrDefault();
            if (Waluta == "Euro")
            {
                dodanaKwota *= 4.5m;
                dodanaKwota = Math.Round(dodanaKwota, 2);
            }
            budzet.pozostala_kwota += dodanaKwota;
            budzet.calkowity_budzet += dodanaKwota;
            db.SaveChanges();
            return budzet.pozostala_kwota;
        }

        public decimal? OdejmijOdBudzetu(int idProjektu, decimal odejmowanaKwota, string Waluta)
        {
            var budzet = (from b in db.BudzetProjektu
                          where b.projekt_id == idProjektu
                          select b).FirstOrDefault();
            if (Waluta == "Euro")
            {
                odejmowanaKwota *= 4.5m;
                odejmowanaKwota = Math.Round(odejmowanaKwota, 2);
            }
            budzet.pozostala_kwota -= odejmowanaKwota;
            budzet.calkowity_budzet -= odejmowanaKwota;
            db.SaveChanges();
            return budzet.pozostala_kwota;
        }

        public (decimal? PozostalaKwotaPLN, decimal? PozostalaKwotaEuro, decimal? CalkowityBudzetPLN,
            decimal? CalkowityBudzetEURO, decimal? WydanaKwotaPLN, decimal? WydanaKowotaEuro)
            ObliczWartosci(int idProjektu)
        {
            decimal kursEuroNaPln = 4.5m;
            decimal? pozostalaKwotaPLN = null;
            decimal? pozostalaKwotaEuro = null;
            decimal? calkowityBudzetPLN = null;
            decimal? calkowityBudzetEURO = null;
            decimal? wydanaKwotaPLN = null;
            decimal? wydanaKwotaEuro = null;


            
                pozostalaKwotaPLN = WyswietlPozostalaKwota(idProjektu);
                calkowityBudzetPLN = WyswietlCalkowityBudzet(idProjektu);
                wydanaKwotaPLN = WyswietlWydanaKwote(idProjektu);
                pozostalaKwotaEuro =  Math.Round(pozostalaKwotaPLN.GetValueOrDefault() / kursEuroNaPln, 2);
                calkowityBudzetEURO = Math.Round(calkowityBudzetPLN.GetValueOrDefault() / kursEuroNaPln, 2);
                wydanaKwotaEuro = Math.Round(wydanaKwotaPLN.GetValueOrDefault() / kursEuroNaPln, 2);
           


            return (pozostalaKwotaPLN, pozostalaKwotaEuro, calkowityBudzetPLN, calkowityBudzetEURO, wydanaKwotaPLN, wydanaKwotaEuro);
            #endregion
        }

        public string GenerujRecenzjeBudzetu(int idProjektu)
        {
            Projekty projekt = db.Projekty.FirstOrDefault(p => p.projekt_id == idProjektu);
            if (projekt == null)
            {
                return "Projekt nie został znaleziony.";
            }

            var wartosciBudzetu = ObliczWartosci(projekt.projekt_id);
            var terminProjektu = projekt.termin;
            if (terminProjektu == null)
            {
                return "Termin projektu nie został określony.";
            }
            var dataRozpoczecia = projekt.data_rozpoczecia;
            var IloscTrwaniaProjketu = terminProjektu.Value - dataRozpoczecia.Value;

            var dzisiaj = DateTime.Now;
            var pozostalyCzas = terminProjektu.Value - dzisiaj;

            if (pozostalyCzas.TotalDays <= 0)
            {
                return "Projekt przekroczył termin.";
            }

            var ZakladanydziennBudzetPLN = Math.Round(wartosciBudzetu.CalkowityBudzetPLN.GetValueOrDefault() / (decimal)IloscTrwaniaProjketu.TotalDays, 2);
            var ZakladanydziennBudzetEURO = Math.Round(wartosciBudzetu.CalkowityBudzetEURO.GetValueOrDefault() / (decimal)IloscTrwaniaProjketu.TotalDays, 2);

            var dziennyBudzetPLN = Math.Round(wartosciBudzetu.PozostalaKwotaPLN.GetValueOrDefault() / (decimal)pozostalyCzas.TotalDays, 2);
            var dziennyBudzetEuro = Math.Round(wartosciBudzetu.PozostalaKwotaEuro.GetValueOrDefault() / (decimal)pozostalyCzas.TotalDays, 2);

            var recenzja = new StringBuilder();
            recenzja.AppendLine($"Recenzja budżetu dla projektu: {projekt.nazwa}");
            recenzja.AppendLine($"Całkowity budżet: {wartosciBudzetu.CalkowityBudzetPLN} PLN / {wartosciBudzetu.CalkowityBudzetEURO} EUR");
            recenzja.AppendLine($"Wydana kwota: {wartosciBudzetu.WydanaKwotaPLN} PLN / {wartosciBudzetu.WydanaKowotaEuro} EUR");
            recenzja.AppendLine($"Pozostała kwota: {wartosciBudzetu.PozostalaKwotaPLN} PLN / {wartosciBudzetu.PozostalaKwotaEuro} EUR");
            recenzja.AppendLine($"Pozostały czas do terminu: {pozostalyCzas.Days} dni");
            recenzja.AppendLine($"Dzienny budżet do wydania: {dziennyBudzetPLN} PLN / {dziennyBudzetEuro} EUR");
            recenzja.AppendLine($"Zakładany dzienny budżet do wydania: {ZakladanydziennBudzetPLN} PLN / {ZakladanydziennBudzetEURO} EUR");

            if (dziennyBudzetPLN < 0)
            {
                recenzja.AppendLine("Budżet został przekroczony. Należy zredukować wydatki.");
            }
            else if (dziennyBudzetPLN < ZakladanydziennBudzetPLN)
            {
                var roznica = ZakladanydziennBudzetPLN - dziennyBudzetPLN;
                var kwotaDoDodania = (roznica * (int)pozostalyCzas.TotalDays) * 2;
                recenzja.AppendLine("Budżet jest niski. Należy monitorować wydatki i szukać oszczędności.");
                recenzja.AppendLine($"Aby budżet był w dobrym stanie, należy dodać: {kwotaDoDodania} PLN.");
            }
            else
            {
                recenzja.AppendLine("Budżet jest w dobrym stanie.");
            }

            return recenzja.ToString();
        }

       
    }
}

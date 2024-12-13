using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectManagementApp.ViewModels
{
    public class InfoProjektuViewModel : WszystkieViewModel<InfoProjekt>
    {
        public InfoProjektuViewModel() : base("Informacje Projektu")
        {
        }

        int ProjektID = 1093;
       

        public override void Load()
        {
            // Pobierz dane projektu
            var projekt = zarzadanieProjektami2Entities.Projekty
                .FirstOrDefault(p => p.projekt_id == ProjektID);

            if (projekt == null) return;

            // Pobierz dane z powiązanych tabel
            var ryzyka = projekt.RyzykaProjektu.ToList();
            var pliki = projekt.PlikiProjekty.ToList();
            var notatki = projekt.NotatkiProjekty.ToList();
            var budzety = projekt.BudzetProjektu.ToList();
            var zadania = projekt.Zadania.ToList();

            // Dopasuj długości tabel do najdłuższej listy
            int maxLength = new[] { ryzyka.Count, pliki.Count, notatki.Count, budzety.Count, zadania.Count }.Max();

            // Uzupełnienie krótszych list pustymi rekordami
            ryzyka = ryzyka.Concat(Enumerable.Repeat(new RyzykaProjektu(), maxLength - ryzyka.Count)).ToList();
            pliki = pliki.Concat(Enumerable.Repeat(new PlikiProjekty(), maxLength - pliki.Count)).ToList();
            notatki = notatki.Concat(Enumerable.Repeat(new NotatkiProjekty(), maxLength - notatki.Count)).ToList();
            budzety = budzety.Concat(Enumerable.Repeat(new BudzetProjektu(), maxLength - budzety.Count)).ToList();
            zadania = zadania.Concat(Enumerable.Repeat(new Zadania(), maxLength - zadania.Count)).ToList();

            // Tworzenie listy informacji o projekcie
            var allInfo = ryzyka.Select((ryzyko, index) => new InfoProjekt
            {
                // Dane projektu
                NazwaProjektu = projekt.nazwa,

                // Dane ryzyka
                SrodkiZapobiegawcze = ryzyko.srodki_zapobiegawcze,
                Prawdopodobienstwo = ryzyko.prawdopodobienstwo,
                Wplyw = ryzyko.wplyw,
                Opis = ryzyko.opis,

                // Dane plików
                NazwaPliku = pliki[index].nazwa_pliku,
                SciezkaPliku = pliki[index].sciezka_pliku,
                DataWgraniaPliku = pliki[index].data_wgrania ?? DateTime.MinValue,

                // Dane notatek
                tresc = notatki[index].tresc_notatki,
                DataUtworzeniaNotatki = notatki[index].data_utworzenia ?? DateTime.MinValue,

                // Dane budżetu
                CalkowityBudzet = (double)(budzety[index].calkowity_budzet ?? 0),
                WydanaKwota = (double)(budzety[index].wydana_kwota ?? 0),
                PozostalaKwota = (double)(budzety[index].pozostala_kwota ?? 0),

                // Dane zadań
                NazwaZadania = zadania[index].nazwa,
                OpisZadania = zadania[index].opis
            }).ToList();

            // Filtruj rekordy, które nie są puste (wszystkie wartości muszą być niepuste)
            var nonEmptyInfo = allInfo.Where(info =>
                !string.IsNullOrEmpty(info.SrodkiZapobiegawcze) ||
                !string.IsNullOrEmpty(info.Opis) ||
                !string.IsNullOrEmpty(info.NazwaPliku) ||
                info.DataWgraniaPliku != DateTime.MinValue ||
                info.CalkowityBudzet != 0 ||
                info.WydanaKwota != 0 ||
                info.PozostalaKwota != 0 ||
                !string.IsNullOrEmpty(info.NazwaZadania) ||
                !string.IsNullOrEmpty(info.OpisZadania)
            ).ToList();

            // Przypisanie przefiltrowanej listy do widoku
            List = new ObservableCollection<InfoProjekt>(nonEmptyInfo);
        }


        public override void OpenNewProject()
        {
            // Implementacja otwierania nowego projektu
        }

        public override void OpenInfoView()
        {
            // Implementacja widoku szczegółów projektu
            throw new NotImplementedException();
        }
    }
}

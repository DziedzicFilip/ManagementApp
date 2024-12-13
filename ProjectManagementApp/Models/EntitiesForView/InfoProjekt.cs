using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.Models.EntitiesForView
{
    public class InfoProjekt
    {
        public string NazwaProjektu
        {
            get; set;
        }

        #region Ryzyko
        public string SrodkiZapobiegawcze { get; set; }
        public string Prawdopodobienstwo { get; set; }

        public string Wplyw { get; set; }
        public string Opis { get; set; }
        
        #endregion
        #region CzasPracy
        public double CzasSpedzony {  get; set; }  
        public DateTime DataPomiaruCzasu {  get; set; }
        #endregion
        #region Notatki
        public string tresc { get; set; }
        public DateTime DataUtworzeniaNotatki { get; set; }
        #endregion
        #region Budzet
        public double CalkowityBudzet {  get; set; }
        public double WydanaKwota { get; set; }
        public double PozostalaKwota { get; set; }
        #endregion
        #region Historia Dzialania
        public string Dzialanie {  get; set; }
        public DateTime DataZdarzenia {  get; set; }
        #endregion
        #region PodsumowanieCzasu
        public double CalkowityCzas {  get; set; }
        public DateTime DataRozpoczenciaPodsumowanie { get; set; }
        public DateTime DataZakonczeniaPodsumowanie { get; set; }
        #endregion
        #region Pliki
        public string NazwaPliku { get; set; }
        public string SciezkaPliku { get; set; }
        public DateTime DataWgraniaPliku { get; set; }

        #endregion
        #region Zadania
        public string NazwaZadania { get; set; }
        public string  OpisZadania { get; set; }
        public string StatusZadania { get; set; }
        public DateTime DataRozpoczeciaZadnia { get; set; }
        public DateTime DataZakaonczeniaZadania { get; set; }
        #endregion

    }

}

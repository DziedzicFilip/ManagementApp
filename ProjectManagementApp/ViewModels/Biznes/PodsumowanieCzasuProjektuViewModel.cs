using ProjectManagementApp.Helper;
using ProjectManagementApp.Models.BussinesLogic;
using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LiveCharts;
using LiveCharts.Wpf;
using System.ComponentModel;
using ProjectManagementApp.Models.Walidator;
using System.Windows;

namespace ProjectManagementApp.ViewModels
{
    public class PodsumowanieCzasuProjektuViewModel : WorkspaceViewModel,IDataErrorInfo
    {
        #region DB
        ZarzadanieProjektami2Entities db;
        #endregion

        #region Konstruktor
        public PodsumowanieCzasuProjektuViewModel()
        {
            base.DisplayName = "Podsumowanie Czasu";
            db = new ZarzadanieProjektami2Entities();
        }
        #endregion

        #region Pola
        private decimal? _CalkowityCzas;
        public decimal? CalkowityCzas
        {
            get
            {
                return _CalkowityCzas;
            }
            set
            {
                if (_CalkowityCzas != value)
                {
                    _CalkowityCzas = value;
                    OnPropertyChanged(() => CalkowityCzas);
                }
            }
        }

        private int _IdProjketu;
        public int IdProjketu
        {
            get
            {
                return _IdProjketu;
            }
            set
            {
                if (_IdProjketu != value)
                {
                    _IdProjketu = value;
                    OnPropertyChanged(() => IdProjketu);
                }
            }
        }
        private int? _DniOpoznienia;
        public int? DniOpoznienia
        {
            get
            {
                return _DniOpoznienia;
            }
            set
            {
                if (_DniOpoznienia != value)
                {
                    _DniOpoznienia = value;
                    OnPropertyChanged(() => DniOpoznienia);
                }
            }
        }

        private decimal? _Wartosc;
        public decimal? Wartosc
        {
            get
            {
                return _Wartosc;
            }
            set
            {
                if (_Wartosc != value)
                {
                    _Wartosc = value;
                    OnPropertyChanged(() => Wartosc);
                }
            }
        }

        private decimal? _WartoscEuroBezRabatu;
        public decimal? WartoscEuroBezRabatu
        {
            get
            {
                return _WartoscEuroBezRabatu;
            }
            set
            {
                if (_WartoscEuroBezRabatu != value)
                {
                    _WartoscEuroBezRabatu = value;
                    OnPropertyChanged(() => WartoscEuroBezRabatu);
                }
            }
        }
        private decimal? _WartoscPLNBezRabatu;
        public decimal? WartoscPLNBezRabatu
        {
            get
            {
                return _WartoscPLNBezRabatu;
            }
            set
            {
                if (_WartoscPLNBezRabatu != value)
                {
                    _WartoscPLNBezRabatu = value;
                    OnPropertyChanged(() => WartoscPLNBezRabatu);
                }
            }
        }

        private decimal? _wartoscNettoPLN;
        private decimal? _wartoscNettoEUR;
        private decimal? _wartoscBruttoPLN;
        private decimal? _wartoscBruttoEUR;

        public decimal? WartoscNettoPLN
        {
            get => _wartoscNettoPLN;
            set
            {
                _wartoscNettoPLN = value;
                OnPropertyChanged(() => WartoscNettoPLN);
            }
        }

        public decimal? WartoscNettoEUR
        {
            get => _wartoscNettoEUR;
            set
            {
                _wartoscNettoEUR = value;
                OnPropertyChanged(() => WartoscNettoEUR);
            }
        }

        public decimal? WartoscBruttoPLN
        {
            get => _wartoscBruttoPLN;
            set
            {
                _wartoscBruttoPLN = value;
                OnPropertyChanged(() => WartoscBruttoPLN);
            }
        }

        public decimal? WartoscBruttoEUR
        {
            get => _wartoscBruttoEUR;
            set
            {
                _wartoscBruttoEUR = value;
                OnPropertyChanged(() => WartoscBruttoEUR);
            }
        }
        private string _WybranaWaluta;
        public string WybranaWaluta
        {
            get => _WybranaWaluta;
            set
            {
                if (_WybranaWaluta != value)
                {
                    _WybranaWaluta = value;
                    OnPropertyChanged(() => WybranaWaluta);
                }
            }
        }


        private decimal _StawkaGodzinowa;
        public decimal StawkaGodzinowa
        {
            get
            {
                return _StawkaGodzinowa;
            }
            set
            {
                if (_StawkaGodzinowa != value)
                {
                    _StawkaGodzinowa = value;
                    OnPropertyChanged(() => StawkaGodzinowa);
                }
            }
        }

        private string _WybranyTypUmowy;
        public string WybranyTypUmowy
        {
            get => _WybranyTypUmowy;
            set
            {
                if (_WybranyTypUmowy != value)
                {
                    _WybranyTypUmowy = value;
                    OnPropertyChanged(() => WybranyTypUmowy);
                }
            }
        }

        private decimal _Rabat;
        public decimal Rabat
        {
            get
            {
                return _Rabat;
            }
            set
            {
                if (_Rabat != value)
                {
                    _Rabat = value;
                    OnPropertyChanged(() => Rabat);
                }
            }
        }

        private List<RejestrCzasuPracyProjekt> _RejestrCzasuDane;
        public List<RejestrCzasuPracyProjekt> RejestrCzasuDane
        {
            get
            {
                return _RejestrCzasuDane;
            }
            set
            {
                if (_RejestrCzasuDane != value)
                {
                    _RejestrCzasuDane = value;
                    OnPropertyChanged(() => RejestrCzasuDane);
                }
            }
        }

        private List<Zadania> _Zadania;
        public List<Zadania> Zadania
        {
            get
            {
                return _Zadania;
            }
            set
            {
                if (_Zadania != value)
                {
                    _Zadania = value;
                    OnPropertyChanged(() => Zadania);
                }
            }
        }

        private int _LiczbaWykonanychZadan;
        public int LiczbaWykonanychZadan
        {
            get
            {
                return _LiczbaWykonanychZadan;
            }
            set
            {
                if (_LiczbaWykonanychZadan != value)
                {
                    _LiczbaWykonanychZadan = value;
                    OnPropertyChanged(() => LiczbaWykonanychZadan);
                }
            }
        }

        private int _LiczbaZadan;
        public int LiczbaZadan
        {
            get
            {
                return _LiczbaZadan;
            }
            set
            {
                if (_LiczbaZadan != value)
                {
                    _LiczbaZadan = value;
                    OnPropertyChanged(() => LiczbaZadan);
                }
            }
        }
        private SeriesCollection _wykonaneZadaniaSeries;
        public SeriesCollection WykonaneZadaniaSeries
        {
            get { return _wykonaneZadaniaSeries; }
            set
            {
                _wykonaneZadaniaSeries = value;
                OnPropertyChanged(()=>WykonaneZadaniaSeries);
            }
        }
        private PdfGenerator pdfGenerator;
        private DateTime _DataWystawienia=DateTime.Now;
        public DateTime DataWystawienia
        {
            get
            {
                return _DataWystawienia;
            }
            set
            {
               
                    _DataWystawienia = value;
                    OnPropertyChanged(() => DataWystawienia);
                
            }
        }

        #region      Walidacja
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "StawkaGodzinowa")
                   komunikat = BiznesWalidator.SprawdzLiczbeNieUjemna(StawkaGodzinowa);



                return komunikat;
            }
        }
        #endregion
        public IQueryable<KeyAndValue> ProjketyItems
        {
            get
            {
                return new ProjektB(db).GetProjektyKeyAndValue();
            }
        }
        #endregion

        #region Commands
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {
                    _ObliczCommand = new BaseCommand(() => ObliczWartosc());
                }
                return _ObliczCommand;
            }
        }

        //private void ObliczWartosc()
        //{
        //    CalkowityCzas = new PodsumowanieCzasuB(db).CalkowityCzasReturnVariable(IdProjketu);
        //    DniOpoznienia= new PodsumowanieCzasuB(db).ObliczDniOpoznienia(IdProjketu);
        //    Rabat = new StawkaGodzinowaB(db).Rabat(DniOpoznienia ?? 0, IdProjketu, StawkaGodzinowa);
        //    LiczbaWykonanychZadan = new PodsumowanieCzasuB(db).LiczbaWykonanychZadan(IdProjketu);
        //    LiczbaZadan = new PodsumowanieCzasuB(db).LiczbaZadan(IdProjketu);
        //    decimal kursEuroNaPln = 4.5m;
        //    decimal VatRate=0.23m;

        //    switch (WybranyTypUmowy)
        //    {
        //        case "Dzieło":
        //            VatRate= 0m;
        //            break;
        //        case "Zlecenie":
        //            VatRate = 0m;
        //            break;
        //        case "B2B":
        //            VatRate = 0.23m;
        //            break;
        //    }

        //    if (WybranaWaluta == "PLN")
        //    {
        //        WartoscBruttoPLN = Math.Round((new StawkaGodzinowaB(db).Stawka(IdProjketu, StawkaGodzinowa, "PLN") ?? 0), 2);
        //        WartoscNettoPLN = Math.Round((WartoscBruttoPLN.GetValueOrDefault() * (1 - VatRate)), 2);
        //        WartoscBruttoEUR = Math.Round((WartoscBruttoPLN.GetValueOrDefault() / kursEuroNaPln), 2);
        //        WartoscNettoEUR = Math.Round((WartoscBruttoEUR.GetValueOrDefault() * (1 - VatRate)), 2);
        //        WartoscPLNBezRabatu = Math.Round(((new StawkaGodzinowaB(db).Stawka (IdProjketu, StawkaGodzinowa) / kursEuroNaPln ) * (1 - VatRate) ?? 0), 2);
        //    }
        //    else
        //    {
        //        WartoscBruttoEUR = Math.Round((new StawkaGodzinowaB(db).Stawka(IdProjketu, StawkaGodzinowa, "EURO") ?? 0), 2);
        //        WartoscNettoEUR = Math.Round((WartoscBruttoEUR.GetValueOrDefault() * (1 - VatRate)), 2);
        //        WartoscEuroBezRabatu = Math.Round((new StawkaGodzinowaB(db).Stawka(IdProjketu, StawkaGodzinowa) * (1 - VatRate) ?? 0), 2);
        //        WartoscBruttoPLN = Math.Round((WartoscBruttoEUR.GetValueOrDefault() * kursEuroNaPln), 2);
        //        WartoscNettoPLN = Math.Round((WartoscBruttoPLN.GetValueOrDefault() * (1 - VatRate)), 2);
        //    }
        //    Load();
        //}

       
        private void ObliczWartosc()
        {
            
            
                CalkowityCzas = new PodsumowanieCzasuB(db).CalkowityCzasReturnVariable(IdProjketu);
                DniOpoznienia = new PodsumowanieCzasuB(db).ObliczDniOpoznienia(IdProjketu);
                Rabat = new StawkaGodzinowaB(db).Rabat(DniOpoznienia ?? 0, IdProjketu, StawkaGodzinowa);
                LiczbaWykonanychZadan = new PodsumowanieCzasuB(db).LiczbaWykonanychZadan(IdProjketu);
                LiczbaZadan = new PodsumowanieCzasuB(db).LiczbaZadan(IdProjketu);

                var stawkaGodzinowaB = new StawkaGodzinowaB(db);
                var wyniki = stawkaGodzinowaB.ObliczWartosci(IdProjketu, StawkaGodzinowa, WybranaWaluta, WybranyTypUmowy);

                WartoscBruttoPLN = wyniki.WartoscBruttoPLN;
                WartoscNettoPLN = wyniki.WartoscNettoPLN;
                WartoscBruttoEUR = wyniki.WartoscBruttoEUR;
                WartoscNettoEUR = wyniki.WartoscNettoEUR;
                WartoscPLNBezRabatu = wyniki.WartoscPLNBezRabatu;
                WartoscEuroBezRabatu = wyniki.WartoscEuroBezRabatu;
                Load();
            
           
            
        }







        

        private void Load()
        {
            RejestrCzasuDane = new PodsumowanieCzasuB(db).PobierzDaneRejestrCzasu(IdProjketu);
            Zadania = new PodsumowanieCzasuB(db).PobierzZadaniaProjektu(IdProjketu);
            LoadData();
        }
        #endregion

        private void LoadData()
        {
            var daneWykresu = new PodsumowanieCzasuB(db).PobierzDaneWykresu(IdProjketu);
            LiczbaZadan = daneWykresu.liczbaZadan;
            LiczbaWykonanychZadan = daneWykresu.liczbaWykonanychZadan;

            WykonaneZadaniaSeries = new SeriesCollection
        {
            new PieSeries
            {
                Title = "Wykonane",
                Values = new ChartValues<int> { LiczbaWykonanychZadan },
                DataLabels = true
            },
            new PieSeries
            {
                Title = "Niewykonane",
                Values = new ChartValues<int> { LiczbaZadan - LiczbaWykonanychZadan },
                DataLabels = true
            }
        };
        }

        private BaseCommand _GenerujPdfCommand;
        public ICommand GenerujPdfCommand
        {
            get
            {
                if (_GenerujPdfCommand == null)
                    _GenerujPdfCommand = new BaseCommand(() => GenerujPdf());
                return _GenerujPdfCommand;
            }
            set { }
        }

        private void GenerujPdf()
        {

            try
            {
                pdfGenerator = new PdfGenerator(db);
                string outputPath = pdfGenerator.GetOutputPath(IdProjketu);
                pdfGenerator.GenerateProjectSummaryPdf(IdProjketu, outputPath, CalkowityCzas, DniOpoznienia, WartoscEuroBezRabatu, WartoscPLNBezRabatu, WartoscNettoPLN, WartoscNettoEUR, WartoscBruttoPLN, WartoscBruttoEUR, WybranaWaluta, StawkaGodzinowa, WybranyTypUmowy, Rabat, LiczbaZadan, LiczbaWykonanychZadan, RejestrCzasuDane, Zadania, DataWystawienia);
                ShowMessageBox("Pomyślne wygenerowanie");
            }
            catch (Exception ex)
            {
                // Pokaż szczegółowy komunikat o błędzie
                ShowMessageBox($"Błąd: {ex.Message}\nSzczegóły: {ex.StackTrace}");
            }
        }



    }
}

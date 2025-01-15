using LiveCharts;
using LiveCharts.Wpf;
using ProjectManagementApp.Helper;
using ProjectManagementApp.Models.BussinesLogic;
using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace ProjectManagementApp.ViewModels
{
    public  class BudzetProjektuViewModel : WorkspaceViewModel
    {
        #region DB
        ZarzadanieProjektami2Entities db;
        #endregion
        #region Konstruktor
        public BudzetProjektuViewModel()
        {
            base.DisplayName = "Budzet Projektu";
            db = new ZarzadanieProjektami2Entities();
            //LoadDataCommand = new BaseCommand(LoadDataForSelectedProject);

        }
        #endregion
        #region Pola
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
                    LoadDataForSelectedProject();
                }
            }


        }
        private decimal? _CalkowityBudzet;
        public decimal? CalkowityBudzet
        {
            get
            {
                return _CalkowityBudzet;
            }
            set
            {
                if (_CalkowityBudzet != value)
                {
                    _CalkowityBudzet = value;
                    OnPropertyChanged(() => CalkowityBudzet);
                }
            }
        }

        
        private decimal _WydanaKwota;
        public decimal WydanaKwota
        {
            get
            {
                return _WydanaKwota;
            }
            set
            {
                if (_WydanaKwota != value)
                {
                    _WydanaKwota = value;
                    OnPropertyChanged(() => WydanaKwota);
                }
            }
        }

        
        private decimal? _PozostalaKwota;
        public decimal? PozostalaKwota
        {
            get
            {
                return _PozostalaKwota;
            }
            set
            {
                if (_PozostalaKwota != value)
                {
                    _PozostalaKwota = value;
                    OnPropertyChanged(() => PozostalaKwota);
                }
            }
        }

        private string _WybranaWaluta;
        public string WybranaWaluta
        {
            get
            {
                return _WybranaWaluta;
            }
            set
            {
                if (_WybranaWaluta != value)
                {
                    _WybranaWaluta = value;
                    OnPropertyChanged(() => WybranaWaluta);
                }
            }
        }

        private decimal? _PozostalaKwotaPLN;
        public decimal? PozostalaKwotaPLN
        {
            get
            {
                return _PozostalaKwotaPLN;
            }
            set
            {
                if (_PozostalaKwotaPLN != value)
                {
                    _PozostalaKwotaPLN = value;
                    OnPropertyChanged(() => PozostalaKwotaPLN);
                }
            }
        }
        private decimal? _WydanaKwotaPLN;
        public decimal? WydanaKwotaPLN
        {
            get
            {
                return _WydanaKwotaPLN;
            }
            set
            {
                if (_WydanaKwotaPLN != value)
                {
                    _WydanaKwotaPLN = value;
                    OnPropertyChanged(() => WydanaKwotaPLN);
                }
            }
        }
        private decimal? _CalkowityBudzetPLN;
        public decimal? CalkowityBudzetPLN
        {
            get
            {
                return _CalkowityBudzetPLN;
            }
            set
            {
                if (_CalkowityBudzetPLN != value)
                {
                    _CalkowityBudzetPLN = value;
                    OnPropertyChanged(() => CalkowityBudzetPLN);
                }
            }
        }
        private decimal? _WydanaKwotaEURO;
        public decimal? WydanaKwotaEURO
        {
            get
            {
                return _WydanaKwotaEURO;
            }
            set
            {
                if (_WydanaKwotaEURO != value)
                {
                    _WydanaKwotaEURO = value;
                    OnPropertyChanged(() => WydanaKwotaEURO);
                }
            }
        }
        private decimal? _PozostalaKwotaEURO;
        public decimal? PozostalaKwotaEURO
        {
            get
            {
                return _PozostalaKwotaEURO;
            }
            set
            {
                if (_PozostalaKwotaEURO != value)
                {
                    _PozostalaKwotaEURO = value;
                    OnPropertyChanged(() => PozostalaKwotaEURO);
                }
            }
        }
        private decimal? _CalkowityBudzetEURO;
        public decimal? CalkowityBudzetEURO
        {
            get
            {
                return _CalkowityBudzetEURO;
            }
            set
            {
                if (_CalkowityBudzetEURO != value)
                {
                    _CalkowityBudzetEURO = value;
                    OnPropertyChanged(() => CalkowityBudzetEURO);
                }
            }
        }

        private decimal? _DodajDoBudzetu;
        public decimal? DodajDoBudzetu
        {
            get
            {
                return _DodajDoBudzetu;
            }
            set
            {
                if (_DodajDoBudzetu != value)
                {
                    _DodajDoBudzetu = value;
                    OnPropertyChanged(() => DodajDoBudzetu);
                }
            }
        }

        private decimal? _OdejmijZBudzetu;
        public decimal? OdejmijZBudzetu
        {
            get
            {
                return _OdejmijZBudzetu;
            }
            set
            {
                if (_OdejmijZBudzetu != value)
                {
                    _OdejmijZBudzetu = value;
                    OnPropertyChanged(() => OdejmijZBudzetu);
                }
            }
        }
        private string _Recenzja;
        public string Recenzja
        {
            get
            {
                return _Recenzja;
            }
            set
            {
                if (_Recenzja != value)
                {
                    _Recenzja = value;
                    OnPropertyChanged(() => Recenzja);
                }
            }
        }

        private SeriesCollection _BudzetSeries;
        public SeriesCollection BudzetSeries
        {
            get { return _BudzetSeries; }
            set
            {
                _BudzetSeries = value;
                OnPropertyChanged(() => BudzetSeries);
            }
        }


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

        private BaseCommand _DodajDoBudzetuCommand;
        public ICommand DodajDoBudzetuCommand
        {
            get
            {
                if (_DodajDoBudzetuCommand == null)
                {
                    _DodajDoBudzetuCommand = new BaseCommand(() => DodajDoBudzetuBudzetu());

                }
                return _DodajDoBudzetuCommand;

            }
        }
        private BaseCommand _OdejmijZBudzetuCommand;
        public ICommand OdejmijZBudzetuCommand
        {
            get
            {
                if (_OdejmijZBudzetuCommand == null)
                {
                    _OdejmijZBudzetuCommand = new BaseCommand(() => OdejmijZBudzetuBudzetu());

                }
                return _OdejmijZBudzetuCommand;

            }
        }
       
       


        private void DodajDoBudzetuBudzetu()
        {
            new BudzetProjektuB(db).DodajDoBudzetu(IdProjketu, DodajDoBudzetu ?? 0, WybranaWaluta);
            LoadDataForSelectedProject();
        }
        private void OdejmijZBudzetuBudzetu()
        {
            new BudzetProjektuB(db).OdejmijOdBudzetu(IdProjketu, OdejmijZBudzetu ?? 0,WybranaWaluta);
            LoadDataForSelectedProject();
        }


        private void ObliczWartosc()
        {

            BudzetProjektuB budzetProjektuB = new BudzetProjektuB(db);
            budzetProjektuB.BudzetProjektuKal(IdProjketu, WydanaKwota,WybranaWaluta);
            LoadDataForSelectedProject();
            GenerujRecenzje();

        }

        public ICommand LoadDataCommand { get; private set; }
        private void LoadDataForSelectedProject()
        {
            var wynik = new BudzetProjektuB(db).ObliczWartosci(IdProjketu);

            PozostalaKwotaPLN = wynik.PozostalaKwotaPLN;
            WydanaKwotaPLN = wynik.WydanaKwotaPLN;
            CalkowityBudzetPLN = wynik.CalkowityBudzetPLN;

            WydanaKwotaEURO = wynik.WydanaKowotaEuro;
            PozostalaKwotaEURO = wynik.PozostalaKwotaEuro;
            CalkowityBudzetEURO = wynik.CalkowityBudzetEURO;
            GenerujRecenzje();
            LoadData();


        }
        private void GenerujRecenzje()
        {
            
                Recenzja = new BudzetProjektuB(db).GenerujRecenzjeBudzetu(IdProjketu);
            
           
        }

        private PdfGenerator pdfGenerator;
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
            var pdfGenerator = new PdfGenerator(db);
            var outputPath = pdfGenerator.GetOutputPathBudget(IdProjketu);
            pdfGenerator.GenerateBudgetPdf(IdProjketu, Recenzja, outputPath);
        }


        public void LoadData()
        {
            var daneWykresu=new BudzetProjektuB(db).ObliczWartosci(IdProjketu);
            BudzetSeries = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Budzet PLN",
                    Values = new ChartValues<decimal> { daneWykresu.CalkowityBudzetPLN.GetValueOrDefault() }
                },
                new ColumnSeries
                {
                    Title = "Wydana kwota PLN ",
                    Values = new ChartValues<decimal> { daneWykresu.WydanaKwotaPLN.GetValueOrDefault() }
                },
                new ColumnSeries
                {
                    Title = "Pozostala kwota PLN ",
                    Values = new ChartValues<decimal> { daneWykresu.PozostalaKwotaPLN.GetValueOrDefault() }
                },
                 new ColumnSeries
                {
                    Title = "Budzet EURO",
                    Values = new ChartValues<decimal> { daneWykresu.CalkowityBudzetEURO.GetValueOrDefault() }
                },
                  new ColumnSeries
                {
                    Title = "Wydana kwota EURO ",
                    Values = new ChartValues<decimal> { daneWykresu.WydanaKowotaEuro.GetValueOrDefault() }
                },
                   new ColumnSeries
                {
                    Title = "Pozostala kwota Euro",
                    Values = new ChartValues<decimal> { daneWykresu.PozostalaKwotaEuro.GetValueOrDefault() }
                },


            };


        }
        #endregion
    }
}

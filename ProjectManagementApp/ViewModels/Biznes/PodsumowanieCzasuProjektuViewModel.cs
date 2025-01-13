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

namespace ProjectManagementApp.ViewModels
{
    public class PodsumowanieCzasuProjektuViewModel : WorkspaceViewModel
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

        private void ObliczWartosc()
        {
            CalkowityCzas = new PodsumowanieCzasuB(db).CalkowityCzasReturnVariable(IdProjketu);
            decimal kursEuroNaPln = 4.5m;
            decimal VatRate = 0.23m;

            if (WybranaWaluta == "PLN")
            {
                WartoscBruttoPLN = Math.Round((new StawkaGodzinowaB(db).Stawka(IdProjketu, StawkaGodzinowa, "PLN") ?? 0), 2);
                WartoscNettoPLN = Math.Round((WartoscBruttoPLN.GetValueOrDefault() * (1 - VatRate)), 2);

                WartoscBruttoEUR = Math.Round((WartoscBruttoPLN.GetValueOrDefault() / kursEuroNaPln), 2);
                WartoscNettoEUR = Math.Round((WartoscBruttoEUR.GetValueOrDefault() * (1 - VatRate)), 2);
            }
            else
            {
                WartoscBruttoEUR = Math.Round((new StawkaGodzinowaB(db).Stawka(IdProjketu, StawkaGodzinowa, "EURO") ?? 0), 2);
                WartoscNettoEUR = Math.Round((WartoscBruttoEUR.GetValueOrDefault() * (1 - VatRate)), 2);

                WartoscBruttoPLN = Math.Round((WartoscBruttoEUR.GetValueOrDefault() * kursEuroNaPln), 2);
                WartoscNettoPLN = Math.Round((WartoscBruttoPLN.GetValueOrDefault() * (1 - VatRate)), 2);
            }

            Load();
        }







        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                    _LoadCommand = new BaseCommand(() => Load());
                return _LoadCommand;
            }
            set { }
        }

        private void Load()
        {
            RejestrCzasuDane = new PodsumowanieCzasuB(db).PobierzDaneRejestrCzasu(IdProjketu);
        }
        #endregion

        
      
    }
}

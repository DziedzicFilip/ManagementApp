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
    public class KalkulatorStawkiViewModel : WorkspaceViewModel
    {
        #region DB
        ZarzadanieProjektami2Entities db;
        #endregion
        #region Konstruktor 
        public KalkulatorStawkiViewModel()
        {
            base.DisplayName = "Kalkulator";
            db = new ZarzadanieProjektami2Entities();
            StawkaGodzinowa = 0;
        }
        #endregion
        #region Pola
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
        public ICommand ObliczCommand {
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
            Wartosc = new StawkaGodzinowaB(db).Stawka(IdProjketu, StawkaGodzinowa);
            CalkowityCzas = new PodsumowanieCzasuB(db).CalkowityCzas(IdProjketu);
        }
        #endregion

    }

}

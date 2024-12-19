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
            PozostalaKwota = new BudzetProjektuB(db).BudzetProjektuKal(IdProjketu, WydanaKwota);
            WydanaKwota = new BudzetProjektuB(db).WyswietlWydanaKwote(IdProjketu) ?? 0;
            CalkowityBudzet = new BudzetProjektuB(db).WyswietlCalkowityBudzet(IdProjketu) ?? 0;

        }
        #endregion
    }
}

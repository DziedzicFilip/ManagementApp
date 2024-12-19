﻿using ProjectManagementApp.Helper;
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
                    OnPropertyChanged(()=>CalkowityCzas);
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
        }

        #endregion
    }
}

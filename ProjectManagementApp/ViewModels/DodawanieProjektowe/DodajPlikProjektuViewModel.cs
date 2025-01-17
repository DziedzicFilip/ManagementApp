using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
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
    public  class DodajPlikProjektuViewModel : JedenViewModel<PlikiProjekty>
    {

        public DodajPlikProjektuViewModel():base("Dodaj Pliki") 
        {
            item =new  PlikiProjekty();
        }

        #region Pola
       public string NazwaPliku
        {
            get
            {
                return item.nazwa_pliku;
            }
            set
            {
                item.nazwa_pliku = value;
                OnPropertyChanged(() => NazwaPliku);
            }
        }

        public string SciezkaPliku
        {
            get
            {
                return item.sciezka_pliku;
            }
            set
            {
                item.sciezka_pliku = value;
                OnPropertyChanged(() => SciezkaPliku);
            }
        }

        public DateTime? DataWgraniaPliku
        {
            get
            {
                return item.data_wgrania;
            }
            set
            {
                item.data_wgrania = value;
                OnPropertyChanged(() => DataWgraniaPliku);
            }
        }

        public int? IdProjektu
        {
            get
            {
                return item.projekt_id;
            }
            set
            {
                item.projekt_id = value;
                OnPropertyChanged(() => IdProjektu);
            }
        }

        #endregion

        #region Propertis Dla ComboBox

        public IQueryable<KeyAndValue> ProjketyItems
        {
            get
            {
                return new ProjektB(zarzadanieProjektami2Entities).GetProjektyKeyAndValue();
            }
        }
        #endregion


        #region Commands

        private ICommand _wybierzPlikCommand;
        public ICommand WybierzPlikCommand
        {
            get
            {
                if (_wybierzPlikCommand == null)
                {
                    _wybierzPlikCommand = new BaseCommand(() => WybierzPlik());
                }
                return _wybierzPlikCommand;
            }
        }
        #endregion
        #region Helpers
        public override void ADD()
        {
            DataWgraniaPliku = DateTime.Now;
            zarzadanieProjektami2Entities.PlikiProjekty.Add(item);
            zarzadanieProjektami2Entities.SaveChanges();
        }
       
        public void WybierzPlik()
        {
            PlikiB plikiB = new PlikiB(zarzadanieProjektami2Entities);
            SciezkaPliku = plikiB.WybierzPlik(SciezkaPliku);
            NazwaPliku = SciezkaPliku.Substring(SciezkaPliku.LastIndexOf("\\") + 1);
        }



        #endregion

    }
}

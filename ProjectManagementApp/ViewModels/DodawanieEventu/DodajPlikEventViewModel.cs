using GalaSoft.MvvmLight.Messaging;
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
    public class DodajPlikEventViewModel : JedenViewModel<PlikiWydarzenia>
    {
        public DodajPlikEventViewModel() : base("Dodaj Plik")
        {
            item = new PlikiWydarzenia();
            Messenger.Default.Register<Wydarzenia>(this, getWybraneWydarzenie);
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
        public string NazwaEventu{ get; set; }

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
        public int? WydarzenieID
        {
            get
            {
                return item.wydarzenie_id;
            }
            set
            {
                item.wydarzenie_id = value;
                OnPropertyChanged(() => WydarzenieID);
            }
           
        }

        #endregion
        #region Propertis Dla ComboBox

        public IQueryable<KeyAndValue> EventItems
        {
            get
            {
                return new EventB(zarzadanieProjektami2Entities).GetEventKeyAndValue();
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
            item.data_wgrania = DateTime.Now;
            zarzadanieProjektami2Entities.PlikiWydarzenia.Add(item);
            zarzadanieProjektami2Entities.SaveChanges();

        }

        public void WybierzPlik()
        {
            PlikiB plikiB = new PlikiB(zarzadanieProjektami2Entities);
            SciezkaPliku = plikiB.WybierzPlik(SciezkaPliku);
            NazwaPliku = SciezkaPliku.Substring(SciezkaPliku.LastIndexOf("\\") + 1);

        }

        private BaseCommand _ShowAllEventy;
        public ICommand ShowAllEventyCommand
        {
            get
            {
                if (_ShowAllEventy == null)
                {
                    _ShowAllEventy = new BaseCommand(() => showAllEventy());

                }
                return _ShowAllEventy;
            }
        }
        public void showAllEventy()
        {
        
            Messenger.Default.Send("EventyALL");
        }
        public void getWybraneWydarzenie(Wydarzenia Event)
        {
            NazwaEventu = Event.nazwa;
            WydarzenieID = Event.wydarzenie_id;
            OnPropertyChanged(() => NazwaEventu);
        }
        #endregion

    }
}

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
    public class DodajNotatkeEventViewModel : JedenViewModel<NotatkiWydarzenia>
    {
        public DodajNotatkeEventViewModel() : base("Dodaj Notatke")
        {
            item = new NotatkiWydarzenia();
            Messenger.Default.Register<Wydarzenia>(this, getWybraneWydarzenie);
        }

        #region Pola
            
        public string tresc
        {
            get
            {
                return item.tresc_notatki;
            }
            set
            {
                item.tresc_notatki = value;
                OnPropertyChanged(() => tresc);
            }
        }
        public int? wydarzenie_id
        {
            get
            {
                return item.wydarzenie_id;
            }
            set
            {
                item.wydarzenie_id = value;
                OnPropertyChanged(() => wydarzenie_id);
            }
        }

        #region Propertis Dla ComboBox

        public IQueryable<KeyAndValue> EventItems
        {
            get
            {
                return new EventB(zarzadanieProjektami2Entities).GetEventKeyAndValue();
            }
        }
        #endregion
        #endregion

        #region Helpers
        public override void ADD()
        {
            item.data_utworzenia = DateTime.Now;
            zarzadanieProjektami2Entities.NotatkiWydarzenia.Add(item);
            zarzadanieProjektami2Entities.SaveChanges();
            
        }

        #endregion
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
        public string NazwaEventu { get; set; }
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
    }
}

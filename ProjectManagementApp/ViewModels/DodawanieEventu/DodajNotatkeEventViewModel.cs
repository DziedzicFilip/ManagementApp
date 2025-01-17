using ProjectManagementApp.Models.BussinesLogic;
using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModels
{
    public class DodajNotatkeEventViewModel : JedenViewModel<NotatkiWydarzenia>
    {
        public DodajNotatkeEventViewModel() : base("Dodaj Notatke")
        {
            item = new NotatkiWydarzenia();
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
        }
}

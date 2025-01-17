using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModels
{
    public class NotatkiWindowEventViewModel : WszystkieViewModel<EventInfo>
    {
        public int EventID {  get; set; }
        public NotatkiWindowEventViewModel() :base(" ") {
         
        }
        public override void Load()
        {
            List = new ObservableCollection<EventInfo>
            (
                from NotatkiWydarzenia in zarzadanieProjektami2Entities.NotatkiWydarzenia
             
                select new EventInfo
                {
                    NazwaEventu = NotatkiWydarzenia.Wydarzenia.nazwa,
                    TrescNotatakiEvent = NotatkiWydarzenia.tresc_notatki,
                    DataUtworzeniaNotatkiEvent = NotatkiWydarzenia.data_utworzenia ?? DateTime.Now,


                }

            );
        }


       
    }
}

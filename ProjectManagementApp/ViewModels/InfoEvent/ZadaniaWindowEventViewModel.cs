using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;

namespace ProjectManagementApp.ViewModels
{
    public  class ZadaniaWindowEventViewModel : WszystkieViewModel<EventInfo>
    {
        public int EventID { get; set; }
        public ZadaniaWindowEventViewModel() :base (" ") {
          

        }
        public override void Load()
        {
            List = new ObservableCollection<EventInfo>
            (
                from PlikiWydarzenia in zarzadanieProjektami2Entities.PlikiWydarzenia
              
                select new EventInfo
                {
                    NazwaEventu = PlikiWydarzenia.Wydarzenia.nazwa,
                    NazwaPlikuEvent = PlikiWydarzenia.nazwa_pliku,
                   SciezkaPlikuEvent = PlikiWydarzenia.sciezka_pliku,
                   DataWgraniaPlikuEvent = PlikiWydarzenia.data_wgrania ?? DateTime.Now,


                }

            );
        }


       
    }
}

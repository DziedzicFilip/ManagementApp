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
        public ZadaniaWindowEventViewModel(int eventID) :base (" ") {
            EventID = eventID;

        }
        public override void Load()
        {
            List = new ObservableCollection<EventInfo>
            (
                from PlikiWydarzenia in zarzadanieProjektami2Entities.PlikiWydarzenia
                where PlikiWydarzenia.wydarzenie_id == EventID
                select new EventInfo
                {
                   NazwaPlikuEvent = PlikiWydarzenia.nazwa_pliku,
                   SciezkaPlikuEvent = PlikiWydarzenia.sciezka_pliku,
                   DataWgraniaPlikuEvent = PlikiWydarzenia.data_wgrania ?? DateTime.Now,


                }

            );
        }


        public override void OpenNewProject()
        {

            //var newProjectWindow = new NowyProjektWindow();
            //newProjectWindow.Show();
        }
        public override void OpenInfoView()
        {
            ///
        }
    }
}

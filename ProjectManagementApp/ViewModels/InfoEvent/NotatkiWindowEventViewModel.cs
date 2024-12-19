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
        public NotatkiWindowEventViewModel(int eventID) :base(" ") {
            EventID = eventID;
        }
        public override void Load()
        {
            List = new ObservableCollection<EventInfo>
            (
                from NotatkiWydarzenia in zarzadanieProjektami2Entities.NotatkiWydarzenia
                where NotatkiWydarzenia.wydarzenie_id == EventID
                select new EventInfo
                {
                    TrescNotatakiEvent = NotatkiWydarzenia.tresc_notatki,
                    DataUtworzeniaNotatkiEvent = NotatkiWydarzenia.data_utworzenia ?? DateTime.Now,


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

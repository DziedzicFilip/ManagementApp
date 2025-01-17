using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ProjectManagementApp.ViewModels
{
    public  class PlikiWindowViewModel : WszystkieViewModel<InfoProjekt>
    {
        public int ProjektID { get; set; }
        public PlikiWindowViewModel() :base(" ") {  }
        public override void Load()
        {
            List = new ObservableCollection<InfoProjekt>
            (
                from PlikiProjekty in zarzadanieProjektami2Entities.PlikiProjekty
              
                select new InfoProjekt
                {
                    NazwaProjektu = PlikiProjekty.Projekty.nazwa,
                    NazwaPliku = PlikiProjekty.nazwa_pliku,
                     SciezkaPliku = PlikiProjekty.sciezka_pliku,
                     DataWgraniaPliku = PlikiProjekty.data_wgrania ?? DateTime.Now,

                }

            );
        }


      

    }
}

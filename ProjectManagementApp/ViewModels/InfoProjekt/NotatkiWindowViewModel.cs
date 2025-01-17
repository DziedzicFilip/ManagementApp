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
    public class NotatkiWindowViewModel :  WszystkieViewModel<InfoProjekt> 
    {
        public int ProjektID { get; set; }
        public NotatkiWindowViewModel() :base(" ") {
           

        }

        public override void Load()
        {
            List = new ObservableCollection<InfoProjekt>
            (
                from NotatkiProjekty in zarzadanieProjektami2Entities.NotatkiProjekty
              
                select new InfoProjekt
                {
                    NazwaProjektu = NotatkiProjekty.Projekty.nazwa,
                    tresc = NotatkiProjekty.tresc_notatki,
                    DataUtworzeniaNotatki = NotatkiProjekty.data_utworzenia ?? DateTime.MinValue,


                }

            );
        }


      

    }
}

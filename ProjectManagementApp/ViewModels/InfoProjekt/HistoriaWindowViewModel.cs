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
    public  class HistoriaWindowViewModel : WszystkieViewModel<InfoProjekt>
    {
        public int ProjektID { get; set; }
        public HistoriaWindowViewModel() :base(" ") {  }

        public override void Load()
        {
            List = new ObservableCollection<InfoProjekt>
            (
                from HistoriaDzialanProjektu in zarzadanieProjektami2Entities.HistoriaDzialanProjektu
               
                select new InfoProjekt
                {
                    NazwaProjektu = HistoriaDzialanProjektu.Projekty.nazwa,
                    Dzialanie = HistoriaDzialanProjektu.dzialanie,
                    DataZdarzenia = HistoriaDzialanProjektu.data_zdarzenia ?? DateTime.Now,

                }

            );
        }


      
    }
}

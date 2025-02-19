﻿using ProjectManagementApp.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProjectManagementApp.Models.Entities;

namespace ProjectManagementApp.ViewModels
{
   public class CzasPracyWindowViewModel : WszystkieViewModel<InfoProjekt>
    {
        public int ProjektID { get; set; }
        public CzasPracyWindowViewModel() :base(" ") {
           


        }
         public override void Load()
        {
            List = new ObservableCollection<InfoProjekt>
            (
                from RejestrCzasuPracyProjekt in zarzadanieProjektami2Entities.RejestrCzasuPracyProjekt
                select new InfoProjekt
                {
                    NazwaProjektu = RejestrCzasuPracyProjekt.Projekty.nazwa,
                    CzasSpedzony = (double)(RejestrCzasuPracyProjekt.czas_spedzony ?? 0m),
                    DataPomiaruCzasu = RejestrCzasuPracyProjekt.data ?? DateTime.Now,

                }

            );
        }


             ///
        
    }
}

﻿using ProjectManagementApp.Models.Entities;
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
        public HistoriaWindowViewModel(int projektID) :base(" ") { ProjektID = projektID; }

        public override void Load()
        {
            List = new ObservableCollection<InfoProjekt>
            (
                from HistoriaDzialanProjektu in zarzadanieProjektami2Entities.HistoriaDzialanProjektu
                where HistoriaDzialanProjektu.projekt_id == ProjektID
                select new InfoProjekt
                {
                    Dzialanie = HistoriaDzialanProjektu.dzialanie,
                    DataZdarzenia = HistoriaDzialanProjektu.data_zdarzenia ?? DateTime.Now,

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

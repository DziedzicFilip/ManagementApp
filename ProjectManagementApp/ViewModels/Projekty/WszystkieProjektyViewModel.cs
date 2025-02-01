using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Helper;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using ProjectManagementApp.Views;
using GalaSoft.MvvmLight.Messaging;

namespace ProjectManagementApp.ViewModels
{
    public class WszystkieProjektyViewModel : WszystkieViewModel<Projekty>
    {
        #region Constructor
        public WszystkieProjektyViewModel()
            : base("Projekty")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Projekty>
            (
                zarzadanieProjektami2Entities.Projekty.ToList()
            );
        }


        #endregion
        #region DoDopracowania
      
       
        #endregion

        #region Props
        private Projekty _SelectedProjekt;
        public Projekty SelectedProjekt
        {
            get
            {
                return _SelectedProjekt;
            }
            set
            {
                
                _SelectedProjekt = value;
                Messenger.Default.Send(_SelectedProjekt);
                OnRequestClose();
            }
        }




        #endregion
        #region  Sort

        public override List<string> GetComoboBoxFindList()
        {
            return new List<string> {"Nazwa", "Priorytet" } ;
        }
        public override List<string> GetComoboBoxSortList()
        {
            return new List<string> { "Nazwa", "Priorytet", "Status","Nazwie i Statusie" };
        }
        public override void Find()
        {
            Load();
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<Projekty>
                (
                    List.Where(item => item.nazwa != null && item.nazwa.Contains(FindText))
                );
            }
            if (FindField == "Priorytet")
            {
                List = new ObservableCollection<Projekty>
                (
                    List.Where(item => item.priorytet != null && item.priorytet.Contains(FindText))
                );
            }

        }
        public override void Sort()
        {
            if(SortField == "Nazwa")
            {
                List = new ObservableCollection<Projekty>
                (
                    List.OrderBy(item => item.nazwa)
                );
            }
            if (SortField == "Priorytet")
            {
                List = new ObservableCollection<Projekty>
                (
                    List.OrderBy(item => item.priorytet)
                );
            }
            if (SortField == "Status")
            {
                List = new ObservableCollection<Projekty>
                (
                    List.OrderBy(item => item.status)
                );
            }
            if (SortField == "Nazwie i Statusie")
            {
                List = new ObservableCollection<Projekty>
                (
                    List.OrderBy(item => item.nazwa).OrderBy(item => item.status)
                );
            }
        }
        #endregion

    }
}
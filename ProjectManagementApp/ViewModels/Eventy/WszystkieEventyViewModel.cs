using GalaSoft.MvvmLight.Messaging;
using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementApp.ViewModels
{
    public class WszystkieEventyViewModel : WszystkieViewModel<Wydarzenia>
    {
          public  WszystkieEventyViewModel():base("Wydarzenia") {

           
            }
        #region Helpers

        public override void Load()
        {
            List = new ObservableCollection<Wydarzenia>
                (
                   zarzadanieProjektami2Entities.Wydarzenia.ToList()
                );
        }



        #endregion
        private Wydarzenia _SelectedEvent;
        public Wydarzenia SelectedEvent
        {
            get
            {
                return _SelectedEvent;
            }
            set
            {

                _SelectedEvent = value;
                Messenger.Default.Send(_SelectedEvent);
                OnRequestClose();
            }
        }

        #region  Sort

        public override List<string> GetComoboBoxFindList()
        {
            return new List<string> { "Nazwa", "Data Zakończenia", "Data Rozpoczęcia" };
        }
        public override List<string> GetComoboBoxSortList()
        {
            return new List<string> { "Nazwa", "Data Zakończenia", "Data Rozpoczęcia"};
        }
        public override void Find()
        {
            Load();
            if (FindField == "Nazwa")
            {
                List = new ObservableCollection<Wydarzenia>
                (
                    List.Where(item => item.nazwa != null && item.nazwa.Contains(FindText))
                );
            }
            if (FindField == "Data Zakończenia")
            {
                List = new ObservableCollection<Wydarzenia>
                (
                    List.Where(item => item.data_zakonczenia != null &&
                        (item.data_zakonczenia.Value.Month.ToString() + "/" +
                         item.data_zakonczenia.Value.Day.ToString()).Contains(FindText))
                );
            }


            if (FindField == "Data Rozpoczęcia")
            {
                List = new ObservableCollection<Wydarzenia>
                (
                    List.Where(item => item.data_rozpoczecia != null &&
                        (item.data_rozpoczecia.Value.Month.ToString() + "/" +
                         item.data_rozpoczecia.Value.Day.ToString()).Contains(FindText))
                );
            }

        }
        public override void Sort()
        {
            if (SortField == "Nazwa")
            {
                List = new ObservableCollection<Wydarzenia>
                (
                    List.OrderBy(item => item.nazwa)
                );
            }
            if(SortField == "Data Zakończenia")
            {
                List = new ObservableCollection<Wydarzenia>
                (
                    List.OrderBy(item => item.data_zakonczenia)
                );
            }
            if(SortField == "Data Rozpoczęcia")
            {
                List = new ObservableCollection<Wydarzenia>
                (
                    List.OrderBy(item => item.data_rozpoczecia)
                );
            }
        }
        #endregion

    }
}

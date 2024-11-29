using ProjectManagementApp.Helper;
using ProjectManagementApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjectManagementApp.ViewModels
{
    public class NowyProjektViewModel : WorkspaceViewModel
    {

        #region DB
        private ZarzadanieProjektami2Entities zarzadanieProjektami2Entities;
        #endregion
        #region Item
        private Projekty projekt;
        #endregion
        #region Command
        private BaseCommand _Add;
        public ICommand Add
        {
            get
            {
                if (_Add == null)
                    _Add = new BaseCommand(() => ADD());
                return _Add;
            }

        }
        private ICommand _Cancel;
        public ICommand Cancel
        {
            get
            {
                if (_Cancel == null)
                    _Cancel = new BaseCommand(() => Close());
                return _Cancel;
            }
        }
        #endregion
        #region Constructor
        public NowyProjektViewModel()
        {

            base.DisplayName = "Nowy Projekt";
            zarzadanieProjektami2Entities = new ZarzadanieProjektami2Entities();
            projekt = new Projekty();
            OnPropertyChanged(() => data_rozpoczecia); 
            OnPropertyChanged(() => termin);
        }
        #endregion
        #region Propertis
        public string Nazwa
        {
            get
            {
                return projekt.nazwa;
            }
            set
            {
                projekt.nazwa = value;
                OnPropertyChanged(() => Nazwa);


            }


        }
        
        public string opis
        {
            get
            {
                return projekt?.opis;

            }
            set
            {
                projekt.opis = value;
                OnPropertyChanged(() => opis);
            }
        }


        public DateTime? data_rozpoczecia
        {
            get => projekt?.data_rozpoczecia ?? DateTime.Now;
            set
            {
                projekt.data_rozpoczecia = value;
                OnPropertyChanged(() => data_rozpoczecia);


            }


        }
        public string status
        {
            get
            {
                return projekt.status;
            }
            set
            {
                projekt.status = value;
                OnPropertyChanged(() => status);

            }


        }

        public string priorytet
        {
            get
            {
                return projekt.priorytet;
            }
            set
            {
                projekt.priorytet = value;
                OnPropertyChanged(() => priorytet);
            }
            
        }

        public DateTime? termin
        {
            get => projekt?.termin ?? DateTime.Now;
            set
            {
                projekt.termin = value;
                OnPropertyChanged(() => termin);

            }
        }



        #endregion


        #region Helpers
     
        public void Close()
        {
            OnRequestClose();
        }
        public void ADD()
        {
            if (projekt.data_rozpoczecia == null )
            {
                projekt.data_rozpoczecia = DateTime.Now;
            }
            if (projekt.termin == null)
                projekt.termin = DateTime.Now.AddDays(7);

            try
            {
                zarzadanieProjektami2Entities.Projekty.Add(projekt);
                zarzadanieProjektami2Entities.SaveChanges();
            }
            catch (Exception ex)
            {
                // Tutaj możesz wyświetlić komunikat o błędzie lub zapisać go do logów
                MessageBox.Show("Wystąpił błąd: " + ex.Message);
            }
            Close();
        }
        #endregion
    }

}




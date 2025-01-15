using CommunityToolkit.Mvvm.Input;
using ProjectManagementApp.Views;
using System;
using System.Windows.Input;

namespace ProjectManagementApp.ViewModels
{
    public class WybierzProjektViewModel : WorkspaceViewModel
    {
        
        public ICommand OpenRyzyko { get; set; }
        public ICommand OpenNotatki { get; set; }
        public ICommand OpenCzasPracy { get; set; }
        public ICommand OpenHistoria { get; set; }
        public ICommand OpenPliki { get; set; }
        public ICommand OpenBUdzet { get; set; }
        public ICommand OpenZadania { get; set; }
        public ICommand OpenPodsumowanie { get; set; }

        public WybierzProjektViewModel()
        {
            base.DisplayName = "Wybierz projekt";

            //OpenRyzyko = new RelayCommand(OpenRyzko);
            //OpenNotatki = new RelayCommand(OpenNotatkiWindow);
            //OpenCzasPracy = new RelayCommand(OpenCzasPracyWindow);
            //OpenHistoria = new RelayCommand(OpenHistoriaWindow);
            //OpenPliki = new RelayCommand(OpenPlikiWindow);
            //OpenBUdzet = new RelayCommand(OpenBudzetWindow);
            //OpenZadania = new RelayCommand(OpenZadaniaWindow);
            //OpenPodsumowanie = new RelayCommand(OpenPodsumowanieWindow);
        }
        private int _projektID;
        public int ProjektID
        {
            get { return _projektID; }
            set
            {
                _projektID = value;
                OnPropertyChanged(() => ProjektID); 
            }
        }


        #region Command Methods

        //public void OpenRyzko()
        //{
        //    Console.WriteLine("Otwarcie okna Ryzyko");
        //    var infoWindow = new RyzkoProjetuWindowView(ProjektID);
        //    infoWindow.Show();
        //}

        //public void OpenNotatkiWindow()
        //{
        //    Console.WriteLine("Otwarcie okna Notatki");
        //    var notatkiWindow = new NotatkiWindowView(ProjektID);  
        //    notatkiWindow.Show();
        //}

        //public void OpenCzasPracyWindow()
        //{
        //    Console.WriteLine("Otwarcie okna Czas Pracy");
        //    //var czasPracyWindow = new CzasPracyWindowView(ProjektID); 
        //    //czasPracyWindow.Show();
        //}

        //public void OpenHistoriaWindow()
        //{
        //    Console.WriteLine("Otwarcie okna Historia");
        //    var historiaWindow = new HistoriaWindowView(ProjektID);  
        //    historiaWindow.Show();
        //}

        //public void OpenPlikiWindow()
        //{
        //    Console.WriteLine("Otwarcie okna Pliki");
        //    var plikiWindow = new PlikiWindowView(ProjektID); 
        //    plikiWindow.Show();
        //}

        //public void OpenBudzetWindow()
        //{
        //    Console.WriteLine("Otwarcie okna Budżet");
        //    var budzetWindow = new OpenBUdzetView(ProjektID); 
        //}

        //public void OpenZadaniaWindow()
        //{
        //    Console.WriteLine("Otwarcie okna Zadania");
        //    var zadaniaWindow = new ZadaniaWindowView(ProjektID);  
        //    zadaniaWindow.Show();
        //}

        //public void OpenPodsumowanieWindow()
        //{
        //    Console.WriteLine("Otwarcie okna Podsumowanie");
        //    var podsumowanieWindow = new PodsumowanieWindowView(ProjektID);  
        //    podsumowanieWindow.Show();
        //}

        #endregion
    }
}

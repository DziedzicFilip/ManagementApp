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

            OpenRyzyko = new RelayCommand(OpenRyzko);
            OpenNotatki = new RelayCommand(OpenNotatkiWindow);
            OpenCzasPracy = new RelayCommand(OpenCzasPracyWindow);
            OpenHistoria = new RelayCommand(OpenHistoriaWindow);
            OpenPliki = new RelayCommand(OpenPlikiWindow);
            OpenBUdzet = new RelayCommand(OpenBudzetWindow);
            OpenZadania = new RelayCommand(OpenZadaniaWindow);
            OpenPodsumowanie = new RelayCommand(OpenPodsumowanieWindow);
        }
        private int _projektID;
        public int ProjektID
        {
            get { return _projektID; }
            set
            {
                _projektID = value;
                OnPropertyChanged(() => ProjektID); // Użycie wyrażenia lambda
            }
        }


        #region Command Methods

        public void OpenRyzko()
        {
            Console.WriteLine("Otwarcie okna Ryzyko");
            var infoWindow = new RyzkoProjetuWindowView(ProjektID);
            infoWindow.Show();
        }

        public void OpenNotatkiWindow()
        {
            Console.WriteLine("Otwarcie okna Notatki");
            var notatkiWindow = new NotatkiWindowView(ProjektID);  // Używaj odpowiedniego widoku
            notatkiWindow.Show();
        }

        public void OpenCzasPracyWindow()
        {
            Console.WriteLine("Otwarcie okna Czas Pracy");
            var czasPracyWindow = new CzasPracyWindowView(ProjektID);  // Używaj odpowiedniego widoku
            czasPracyWindow.Show();
        }

        public void OpenHistoriaWindow()
        {
            Console.WriteLine("Otwarcie okna Historia");
            var historiaWindow = new HistoriaWindowView(ProjektID);  // Używaj odpowiedniego widoku
            historiaWindow.Show();
        }

        public void OpenPlikiWindow()
        {
            Console.WriteLine("Otwarcie okna Pliki");
            var plikiWindow = new PlikiWindowView(ProjektID);  // Używaj odpowiedniego widoku
            plikiWindow.Show();
        }

        public void OpenBudzetWindow()
        {
            Console.WriteLine("Otwarcie okna Budżet");
            var budzetWindow = new OpenBUdzetView(ProjektID);  // Używaj odpowiedniego widoku
            budzetWindow.Show();
        }

        public void OpenZadaniaWindow()
        {
            Console.WriteLine("Otwarcie okna Zadania");
            var zadaniaWindow = new ZadaniaWindowView(ProjektID);  // Używaj odpowiedniego widoku
            zadaniaWindow.Show();
        }

        public void OpenPodsumowanieWindow()
        {
            Console.WriteLine("Otwarcie okna Podsumowanie");
            var podsumowanieWindow = new PodsumowanieWindowView(ProjektID);  // Używaj odpowiedniego widoku
            podsumowanieWindow.Show();
        }

        #endregion
    }
}

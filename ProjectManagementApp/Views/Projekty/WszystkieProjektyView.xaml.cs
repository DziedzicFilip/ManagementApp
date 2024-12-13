using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.ViewModels;
using ProjectManagementApp.Views;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManagementApp.Views
{
    public partial class WszystkieProjektyView : WszystkieViewBase
    {
        public WszystkieProjektyView()
        {
            InitializeComponent();
            this.DataContext = new WszystkieProjektyViewModel();
        }

        // Metoda obsługująca zdarzenie SelectionChanged w DataGrid
        private void ScheduleDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ScheduleDataGrid.SelectedItem is Projekty selectedProject)
            {
                var viewModel = (WszystkieProjektyViewModel)this.DataContext;
                viewModel.OpenProjectDetails(selectedProject);  // Otwarcie okna szczegółów
            }
        }
        public void OpenInfoView()
        {
            //if (int.TryParse(IntInput.Text, out int projektID))
            //{
            //    var infoWindow = new InforProjektuView();
            //    var infoViewModel = new InfoProjektuViewModel(); // Tworzymy ViewModel
            //    infoViewModel.LoadAllForOne(projektID); // Ładujemy dane dla konkretnego projektu
            //    infoWindow.DataContext = infoViewModel;  // Przypisujemy DataContext
            //    infoWindow.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Proszę podać poprawne ID projektu.");
            //}

            var newEventWindow = new InforProjektuView();
            newEventWindow.Show();
        }

    }
}

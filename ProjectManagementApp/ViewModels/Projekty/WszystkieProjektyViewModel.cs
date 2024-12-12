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

namespace ProjectManagementApp.ViewModels
{
    public class WszystkieProjektyViewModel : WszystkieViewModel<Projekty>
    {

        #region Constructor
        public WszystkieProjektyViewModel()
            : base("Projekty")
        {
            OpenNewProjectCommand = new RelayCommand(OpenNewProject);
        }
        #endregion

        #region Properties
        public ICommand OpenNewProjectCommand { get; private set; }
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

        #region Commands
        private void OpenNewProject()
        {
            // Otwieramy nowe okno NowProjektWindow
            var newProjectWindow = new NowyProjektWindow();  // Zmieniamy na NowyProjektWindow
            newProjectWindow.Show();
        }
        #endregion
    }
}
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
        public override void OpenNewProject()
        {
            throw new NotImplementedException();
        }
        #region Commands
        // Otwieranie nowego okna szczegółów projektu
        public void OpenProjectDetails(Projekty selectedProject)
        {
            var projectDetailsWindow = new ProjectDetailsWindow(selectedProject);
            projectDetailsWindow.ShowDialog();  // Użyj ShowDialog() aby czekać na zamknięcie okna
        }
        #endregion
    }
}
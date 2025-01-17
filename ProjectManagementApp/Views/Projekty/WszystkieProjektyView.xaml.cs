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

        
       

    }
}

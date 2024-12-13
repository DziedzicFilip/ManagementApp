using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjectManagementApp.ViewModels;
namespace ProjectManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy PlikiWindowView.xaml
    /// </summary>
    public partial class PlikiWindowView : Window
    {
        public PlikiWindowView(int projektID)
        {
            InitializeComponent();
            this.DataContext = new PlikiWindowViewModel( projektID);
        }
    }
}

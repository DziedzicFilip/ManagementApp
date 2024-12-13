using ProjectManagementApp.Models.Entities;
using ProjectManagementApp.ViewModels;
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

namespace ProjectManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy RyzkoProjetuWindowView.xaml
    /// </summary>
    public partial class RyzkoProjetuWindowView : Window
    {
        public RyzkoProjetuWindowView(int projektID )
        {
            InitializeComponent();
            this.DataContext = new RyzkoProjetuWindowViewModel(projektID);
        }
    }
}

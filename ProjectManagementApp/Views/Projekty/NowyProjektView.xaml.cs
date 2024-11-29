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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy NowyProjektView.xaml
    /// </summary>
    public partial class NowyProjektView : JedenViewBase
    {
        public NowyProjektView()
        {
            InitializeComponent();
        }
        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            string projectName = ProjectNameTextBox.Text;
            string projectDescription = ProjectDescriptionTextBox.Text;
            DateTime? startDate = StartDatePicker.SelectedDate;
            
            string projectStatus = (ProjectStatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string priority = (PriorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            DateTime? deadline = DeadlineDatePicker.SelectedDate;

            // Wykonaj logikę dodawania projektu (np. zapis do bazy danych)

            MessageBox.Show("Projekt został dodany pomyślnie!");

            // Możesz wyczyścić formularz po dodaniu projektu
            ClearForm();
        }

        // Obsługuje kliknięcie przycisku "Anuluj"
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Zamyka UserControl lub zamienia na widok główny
            this.Visibility = Visibility.Collapsed;
        }

        // Funkcja do czyszczenia formularza
        private void ClearForm()
        {
            ProjectNameTextBox.Clear();
            ProjectDescriptionTextBox.Clear();
            StartDatePicker.SelectedDate = null;
           
            ProjectStatusComboBox.SelectedIndex = -1;
            PriorityComboBox.SelectedIndex = -1;
            DeadlineDatePicker.SelectedDate = null;
        }
    }
}

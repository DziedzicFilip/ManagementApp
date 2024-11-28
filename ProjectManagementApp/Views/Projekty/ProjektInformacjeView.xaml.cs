using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManagementApp.Views
{
    public partial class ProjektInformacjeView : UserControl
    {
        public ProjektInformacjeView()
        {
            InitializeComponent();
        }

        // Zakładam, że masz już powiązanie danych (Binding) dla Statusu i Priorytetu
        private void OnStatusChange(object sender, RoutedEventArgs e)
        {
            var selectedStatus = StatusComboBox.SelectedItem as ComboBoxItem;
            if (selectedStatus != null)
            {
                // Zmiana wartości TextBlock Status na wybrany status
                StatusTextBlock.Text = selectedStatus.Content.ToString();
            }
        }

        private void OnPriorityChange(object sender, RoutedEventArgs e)
        {
            var selectedPriority = PriorityComboBox.SelectedItem as ComboBoxItem;
            if (selectedPriority != null)
            {
                // Zmiana wartości TextBlock Priorytet na wybrany priorytet
                PriorityTextBlock.Text = selectedPriority.Content.ToString();
            }
        }

        // Dodanie nowej notatki
        private void OnAddNoteClick(object sender, RoutedEventArgs e)
        {
            // Logika dodawania nowej notatki (np. otwieranie okna do dodawania notatki)
            MessageBox.Show("Tutaj będzie możliwość dodania nowej notatki.");
        }

        // Wybór notatki
        private void OnNoteSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (ListBox)sender;
            var selectedNote = selectedItem.SelectedItem as ListBoxItem;

            if (selectedNote != null)
            {
                var noteTitle = selectedNote.Tag.ToString(); // Używamy Tag jako identyfikator
                MessageBox.Show($"Otwórz szczegóły notatki: {noteTitle}");

                // Logika nawigacji do nowego widoku (np. do widoku szczegółowego notatki)
                // Można to zrobić np. poprzez: NavigationService.Navigate(new WyswietlNotatkeView());
            }
        }

        // Usuwanie notatki
        private void OnDeleteNoteClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                // Uzyskujemy StackPanel, w którym kliknięto przycisk Usuń
                var stackPanel = button.Parent as StackPanel;
                var listBoxItem = stackPanel?.Parent as ListBoxItem;

                if (listBoxItem != null)
                {
                    // Usuwamy notatkę z listy
                    NotatkiListBox.Items.Remove(listBoxItem);
                    MessageBox.Show("Notatka została usunięta.");
                }
            }
        }


        private void OnDeleteFileClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var stackPanel = button.Parent as StackPanel;
                var listBoxItem = stackPanel?.Parent as ListBoxItem;

                if (listBoxItem != null)
                {
                    PlikiListBox.Items.Remove(listBoxItem);
                    MessageBox.Show("Plik został usunięty.");
                }
            }
        }

        // Dodawanie pliku (wybór pliku z systemu)
        private void OnAddFileClick(object sender, RoutedEventArgs e)
        {
            // Otwieranie okna dialogowego wyboru pliku
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName; // Ścieżka do wybranego pliku
                string fileDisplayName = System.IO.Path.GetFileName(fileName); // Wyświetlana nazwa pliku

                // Dodawanie pliku do ListBox
                ListBoxItem fileItem = new ListBoxItem
                {
                    Tag = fileDisplayName,
                    Content = new StackPanel
                    {
                        Children =
                        {
                            new TextBlock { Text = fileDisplayName, FontWeight = FontWeights.Bold },
                            new TextBlock { Text = DateTime.Now.ToString("yyyy-MM-dd"), FontStyle = FontStyles.Italic }
                        }
                    }
                };

                // Dodanie elementu do ListBox
                PlikiListBox.Items.Add(fileItem);
                MessageBox.Show("Plik został dodany.");
            }
        }
        private void ShowDescription_Click(object sender, RoutedEventArgs e)
        {
            // Zidentyfikuj zadanie kliknięte przez użytkownika
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // Znajdź StackPanel, który zawiera opis
                StackPanel taskPanel = clickedButton.Parent as StackPanel;
                if (taskPanel != null)
                {
                    // Poszukaj tekstu opisu w StackPanelu
                    foreach (var child in taskPanel.Children)
                    {
                        if (child is TextBlock textBlock && textBlock.Text.StartsWith("Opis:"))
                        {
                            // Wyświetl opis w MessageBox
                            MessageBox.Show(textBlock.Text, "Opis Zadania", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        }
                    }
                }
            }
        }

        // Zmienianie statusu (opcjonalnie, jeśli chcesz zapisać zmiany)
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                var selectedStatus = (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
                // Logika do zapisywania zmiany statusu zadania
                // Na przykład: Aktualizuj model danych
            }
        }

        private void EditStatus_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var stackPanel = button?.Parent as StackPanel;

            // Zmieniona nazwa z "StatusComboBox" na "StatusComboBox_1"
            var comboBox = stackPanel?.FindName("StatusComboBox_1") as ComboBox;
            var statusTextBlock = stackPanel?.FindName("StatusTextBlock_1") as TextBlock;
            var confirmButton = stackPanel?.FindName("ConfirmStatusButton_1") as Button;

            if (comboBox != null && statusTextBlock != null && confirmButton != null)
            {
                comboBox.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Collapsed;
                confirmButton.Visibility = Visibility.Visible;
            }
        }

        // Kliknięcie w przycisk "Zatwierdź"
        private void ConfirmStatus_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var stackPanel = button?.Parent as StackPanel;

            // Zmieniona nazwa z "StatusComboBox" na "StatusComboBox_1"
            var comboBox = stackPanel?.FindName("StatusComboBox_1") as ComboBox;
            var statusTextBlock = stackPanel?.FindName("StatusTextBlock_1") as TextBlock;
            var editButton = stackPanel?.FindName("EditStatusButton_1") as Button;

            if (comboBox != null && statusTextBlock != null && editButton != null)
            {
                var selectedItem = comboBox.SelectedItem as ComboBoxItem;
                if (selectedItem != null)
                {
                    statusTextBlock.Text = "Status: " + selectedItem.Content.ToString();
                }

                comboBox.Visibility = Visibility.Collapsed;
                editButton.Visibility = Visibility.Visible;
                button.Visibility = Visibility.Collapsed;
            }
        }
    }




}


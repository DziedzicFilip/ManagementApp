using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;

namespace ProjectManagementApp.ViewModels
{
    public class KalendarzViewModel : WorkspaceViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<DayHeaderViewModel> WeekDays { get; set; }

        public KalendarzViewModel()
        {
            WeekDays = new ObservableCollection<DayHeaderViewModel>(GetWeekDays());
        }

        private IEnumerable<DayHeaderViewModel> GetWeekDays()
        {
            var today = DateTime.Today;
            int currentDayOfWeek = (int)today.DayOfWeek; // Pobranie numeru dzisiejszego dnia tygodnia (0 = niedziela)

            // Obliczamy daty tygodnia dla bieżącego tygodnia
            DateTime monday = today.AddDays(-currentDayOfWeek + 1);

            return Enumerable.Range(0, 7).Select(i => new DayHeaderViewModel
            {
                Name = GetDayName(i),
                Date = monday.AddDays(i),
            });
        }

        private string GetDayName(int dayIndex)
        {
            return dayIndex switch
            {
                0 => "Poniedziałek",
                1 => "Wtorek",
                2 => "Środa",
                3 => "Czwartek",
                4 => "Piątek",
                5 => "Sobota",
                6 => "Niedziela",
                _ => string.Empty,
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class DayHeaderViewModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}

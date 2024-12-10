using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectManagementApp.ViewModels
{
    public class KalendarzViewModel : WorkspaceViewModel
    {
        public ObservableCollection<DayViewModel> WeekEvents { get; set; }

        public KalendarzViewModel()
        {
            WeekEvents = GenerateWeekEvents();
        }

        private ObservableCollection<DayViewModel> GenerateWeekEvents()
        {
            var today = DateTime.Today;
            var mondayOfWeek = today.AddDays(DayOfWeek.Monday - today.DayOfWeek);

            // Tworzenie dni tygodnia z przykładowymi eventami
            return new ObservableCollection<DayViewModel>(
                Enumerable.Range(0, 7)
                          .Select(i => new DayViewModel
                          {
                              Date = mondayOfWeek.AddDays(i),
                              DayName = Enum.GetName(typeof(DayOfWeek), DayOfWeek.Monday + i),
                              Events = new ObservableCollection<EventViewModel>
                              {
                                  new EventViewModel { Title = $"Event 1 - {mondayOfWeek.AddDays(i):dd.MM}" },
                                  new EventViewModel { Title = $"Event 2 - {mondayOfWeek.AddDays(i):dd.MM}" },
                                  new EventViewModel { Title = $"Event 3 - {mondayOfWeek.AddDays(i):dd.MM}" }
                              },
                              DayIndex = i
                          })
            );
        }
    }

    public class DayViewModel
    {
        public string DayName { get; set; }
        public DateTime Date { get; set; }
        public ObservableCollection<EventViewModel> Events { get; set; }
        public int DayIndex { get; set; }
    }

    public class EventViewModel
    {
        public string Title { get; set; }
    }
}

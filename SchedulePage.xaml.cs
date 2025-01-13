using XFitnessApp2.Models;

namespace XFitnessApp2
{
    public partial class SchedulePage : ContentPage
    {
        public SchedulePage()
        {
            InitializeComponent();
            LoadSchedules();
        }

        private void LoadSchedules()
        {
            var schedules = App.Database.GetSchedules();
            ScheduleListView.ItemsSource = schedules;
        }
    }
}

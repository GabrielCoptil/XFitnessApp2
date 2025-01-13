using XFitnessApp2.Models;

namespace XFitnessApp2
{
    public partial class ScheduleAdminPage : ContentPage
    {
        private Schedule _selectedSchedule;

        public ScheduleAdminPage()
        {
            InitializeComponent();
            LoadSchedules();
        }

        private void LoadSchedules()
        {
            var schedules = App.Database.GetSchedules();
            ScheduleListView.ItemsSource = schedules;
        }

        private void OnAddClassClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ClassEntry.Text) &&
                double.TryParse(DurationEntry.Text, out double duration))
            {
                var schedule = new Schedule
                {
                    Clasa = ClassEntry.Text,
                    TimpClasa = duration,
                    Date = DatePicker.Date
                };

                App.Database.SaveSchedule(schedule);
                LoadSchedules();

                ClassEntry.Text = string.Empty;
                DurationEntry.Text = string.Empty;
                DatePicker.Date = DateTime.Today;

                DisplayAlert("Succes", "Clasa a fost adăugată!", "OK");
            }
            else
            {
                DisplayAlert("Eroare", "Completează toate câmpurile corect!", "OK");
            }
        }

        private void OnScheduleSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedSchedule = (Schedule)e.SelectedItem;
            DeleteButton.IsEnabled = _selectedSchedule != null;
        }

        private void OnDeleteClassClicked(object sender, EventArgs e)
        {
            if (_selectedSchedule != null)
            {
                App.Database.DeleteSchedule(_selectedSchedule.Id);
                LoadSchedules();

                DeleteButton.IsEnabled = false;
                _selectedSchedule = null;

                DisplayAlert("Succes", "Clasa a fost ștearsă!", "OK");
            }
        }
    }
}

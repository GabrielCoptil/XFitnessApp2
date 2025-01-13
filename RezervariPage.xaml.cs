using XFitnessApp2.Models;

namespace XFitnessApp2
{
    public partial class RezervariPage : ContentPage
    {
        private Schedule _selectedSchedule;
        private Rezervare _selectedRezervare;


        public RezervariPage()
        {
            InitializeComponent();
            LoadSchedules();
            LoadUserReservations();
        }
        private void LoadSchedules()
        {
            var schedules = App.Database.GetSchedules();
            AvailableSchedulesListView.ItemsSource = schedules;
        }

        private void LoadUserReservations()
        {
            var rezervari = App.Database.GetRezervari()
                .Where(r => r.UserId == LoginPage.CurrentUser.Id) 
                .ToList();

            foreach (var rezervare in rezervari)
            {
                rezervare.Schedule = App.Database.GetSchedules()
                    .FirstOrDefault(s => s.Id == rezervare.ScheduleId);
            }

            UserReservationsListView.ItemsSource = rezervari;
        }

        private void OnScheduleSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedSchedule = (Schedule)e.SelectedItem;
            ReserveButton.IsEnabled = _selectedSchedule != null;
        }

        private void OnRezervareSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedRezervare = (Rezervare)e.SelectedItem;
            DeleteButton.IsEnabled = _selectedRezervare != null;
        }
        private void OnDeleteClassClicked(object sender, EventArgs e)
        {
            if (_selectedRezervare != null)
            {
                App.Database.DeleteRezervare(_selectedRezervare.Id);
                LoadUserReservations();

                DeleteButton.IsEnabled = false;
                _selectedSchedule = null;

                DisplayAlert("Succes", "Rezervarea a fost ștearsă!", "OK");
            }
        }

        private void OnReserveClicked(object sender, EventArgs e)
        {
            if (_selectedSchedule != null)
            {
                var rezervare = new Rezervare
                {
                    UserId = LoginPage.CurrentUser.Id,
                    ScheduleId = _selectedSchedule.Id
                };

                App.Database.SaveRezervare(rezervare);

                DisplayAlert("Succes", "Clasa a fost rezervată!", "OK");

                ReserveButton.IsEnabled = false;
                LoadUserReservations();
            }
        }
    }
}

using XFitnessApp2.Models;

namespace XFitnessApp2
{
    public partial class AdminRezervariPage : ContentPage
    {
        public AdminRezervariPage()
        {
            InitializeComponent();
            LoadAllReservations();
        }

        public async void OnBtClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ScheduleAdminPage");
        }

        private void LoadAllReservations()
        {
            var rezervari = App.Database.GetRezervari();

            foreach (var rezervare in rezervari)
            {
                rezervare.User = App.Database.GetUsers().FirstOrDefault(u => u.Id == rezervare.UserId);
                rezervare.Schedule = App.Database.GetSchedules().FirstOrDefault(s => s.Id == rezervare.ScheduleId);
            }

            AllReservationsListView.ItemsSource = rezervari;
        }
    }
}

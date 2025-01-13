using XFitnessApp2.Models;

namespace XFitnessApp2
{
    public partial class LoginPage : ContentPage
    {
        public static User CurrentUser { get; private set; }

        public LoginPage()
        {
            InitializeComponent();
        }
        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("RegisterPage");
        }


        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;
            var user = App.Database.GetUserByUsername(username);

            if (user != null && user.Password == password)
            {
                CurrentUser = user;
                if (user.Role == "Client")
                {
                    await Shell.Current.GoToAsync("RezervariPage");
                }
                else if (user.Role == "Administrator" || user.Role == "PT")
                {
                    await Shell.Current.GoToAsync("AdminRezervariPage");
                }
            }
            else
            {
                await DisplayAlert("Eroare", "Username sau parola incorectă!", "OK");
            }
        }
    }
}

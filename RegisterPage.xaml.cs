using Microsoft.Maui.Storage;
using XFitnessApp2.Models;

namespace XFitnessApp2
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;
            var role = RolePicker.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(role))
            {
                await DisplayAlert("Eroare", "Completează toate câmpurile!", "OK");
                return;
            }

            var existingUser = App.Database.GetUserByUsername(username);
            if (existingUser != null)
            {
                await DisplayAlert("Eroare", "Acest username este deja utilizat!", "OK");
                return;
            }

            var newUser = new User
            {
                Username = username,
                Password = password,
                Role = role
            };

            App.Database.SaveUser(newUser);

            await DisplayAlert("Succes", "Cont creat cu succes!", "OK");
            await Shell.Current.GoToAsync("LoginPage");
        }
    }
}

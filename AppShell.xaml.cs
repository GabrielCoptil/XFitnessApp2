namespace XFitnessApp2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("SchedulePage", typeof(SchedulePage));
            Routing.RegisterRoute("RegisterPage", typeof(RegisterPage));
          Routing.RegisterRoute("RezervariPage", typeof(RezervariPage));
            Routing.RegisterRoute("ScheduleAdminPage", typeof(ScheduleAdminPage));
            Routing.RegisterRoute("AdminRezervariPage", typeof(AdminRezervariPage));

            InitializeComponent();
        }
    }
}

using XFitnessApp2.Data;

namespace XFitnessApp2
{
    public partial class App : Application
    {
        private static XFitnessApp2Database _database;

        public static XFitnessApp2Database Database
        {
            get
            {
                if (_database == null)
                {
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XFitnessApp2.db3");
                    _database = new XFitnessApp2Database(dbPath);
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}

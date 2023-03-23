using Xamarin.Forms;

namespace CampusCrib
{
    public partial class App : Application
    {
        public Hostel selectedHostel = new Hostel();

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new NavigationPage(new MainPage());

            // Add default 'admin / password' user account.

            HostelDatabase newDBInstance;
            newDBInstance = new HostelDatabase();

            var admin = new User
            {
                Username = "admin",
                Password = "password"
            };

            // Only needs to be added once
            //newDBInstance.AddUser(admin);
        }

        // Track the currently logged in user for booking creation and fetching 'my bookings'
        public string currentUser = null;

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

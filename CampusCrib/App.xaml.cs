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
            // This user might be getting duplicated since code runs on every app launch, maybe need validation in the 'AddUser' function
            // Or maybe this code should be moved somewhere else?

            HostelDatabase newDBInstance;
            newDBInstance = new HostelDatabase();

            var admin = new User
            {
                Username = "admin",
                Password = "password"
            };

            newDBInstance.AddUser(admin);
        }

        // Track the currently logged in user for booking creation and fetching 'my bookings'
        public string currentUser;

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

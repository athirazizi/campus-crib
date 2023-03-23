using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CampusCrib
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingsPage : ContentPage
    {
        private BookingsPageVM bookingspagevm;

        public BookingsPage()
        {
            InitializeComponent();
            bookingspagevm = new BookingsPageVM();
            BindingContext = bookingspagevm;
        }


        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            App globalref = (App)Application.Current;

            var selectedBooking = ((ListView)sender).SelectedItem as Booking;

            globalref.selectedBooking = selectedBooking;


            Navigation.PushAsync(new BookingDetailsPage());


            // Need to deselect the item on the UI after this, otherwise it will stick
        }
    }
}
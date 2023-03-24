using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CampusCrib
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateBookingPage : ContentPage
    {
        CreateBookingPageVM createbookingpagevm;

        public CreateBookingPage()
        {
            InitializeComponent();

            createbookingpagevm = new CreateBookingPageVM();
            BindingContext = createbookingpagevm;
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void btnCreate_Clicked(object sender, EventArgs e)
        {
            // save the booking
            createbookingpagevm.SaveBooking();

        }
    }
}
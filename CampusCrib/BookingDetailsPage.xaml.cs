using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CampusCrib
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingDetailsPage : ContentPage
    {

        BookingDetailsPageVM bookingdetailspagevm;

        public BookingDetailsPage()
        {
            InitializeComponent();

            bookingdetailspagevm = new BookingDetailsPageVM();
            BindingContext = bookingdetailspagevm;
        }

        private void btnUpdate_Clicked(object sender, EventArgs e)
        {
            bookingdetailspagevm.UpdateBooking();
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            bookingdetailspagevm.DeleteBooking();
        }
    }
}
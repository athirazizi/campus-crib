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
    public partial class BookingsPage : ContentPage
    {

        BookingsPageVM bookingspagevm;

        public BookingsPage()
        {
            InitializeComponent();
            bookingspagevm = new BookingsPageVM();
            BindingContext = bookingspagevm;
        }

        

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BanKuy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Servicios : ContentPage
    {
        public Servicios()
        {
            InitializeComponent();
        }

        private async void btnAgua_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Agua());
        }

        private async void btnLuz_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Luz());
        }
    }
}
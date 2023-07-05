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
    public partial class ConfirmarPagoServicio : ContentPage
    {
        public ConfirmarPagoServicio()
        {
            InitializeComponent();
        }

        private async void btnConfirmarPago_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ComprobanteServicio());
        }

        private async void btnCancelar_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}
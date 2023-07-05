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
    public partial class TransferenciaInterbancaria : ContentPage
    {
        public string montoo;
        public string idCuenta;

        public TransferenciaInterbancaria(string monto,string idcuenta)
        {
            InitializeComponent();
            this.montoo = monto;
            this.idCuenta=idcuenta;
        }

        private async void btnPichincha_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransferenciaInterbancaria2("Pichinca",this.montoo,this.idCuenta));
        }

        private async void btnGuayaquil_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransferenciaInterbancaria2("Guayaquil", this.montoo, this.idCuenta));

        }

        private async void btnPacifico_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransferenciaInterbancaria2("Pacifico", this.montoo, this.idCuenta));

        }

        private async void btnAustro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransferenciaInterbancaria2("Austro", this.montoo, this.idCuenta));

        }

        private async void btnProdubanco_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransferenciaInterbancaria2("Produbanco", this.montoo, this.idCuenta));

        }
    }
}
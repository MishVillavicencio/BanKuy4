using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BanKuy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransferenciaInterbancaria2 : ContentPage
    {
        public double Montoo;
        public string idCuenta;

        public TransferenciaInterbancaria2(string nombreBancoo,string montoo,string idcuentaa)
        {
            InitializeComponent();
            nombrBanco.Text = nombreBancoo.ToString();
            this.Montoo = double.Parse(montoo);
            this.idCuenta = idcuentaa.ToString();
        }

        private async void btnContinuar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMonto.Text))
            {
                await DisplayAlert("Error", "No ha ingresado una cantidad", "Ok");
                return;
            }

            double Monto = double.Parse(txtMonto.Text);

            if (Monto > this.Montoo)
            {
                await DisplayAlert("Error", "Ha ingresado una cantidad superior a la que tiene en su cuenta", "Ok");
                return;
            }

            await Navigation.PushAsync(new ConfirmarTransferencia(this.idCuenta, txtNcuenta.Text, txtMonto.Text,nombrBanco.Text,2));

        }
    }
}
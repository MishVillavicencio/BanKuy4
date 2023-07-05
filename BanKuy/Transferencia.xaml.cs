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
    public partial class Transferencia : ContentPage
    {
        public string montoo;
        public string idcuentaa;

        public Transferencia(string idCuenta,string monto)
        {
            InitializeComponent();
            idcuenta.Text=idCuenta.ToString();
            this.montoo= monto;
            idMonto.Text=monto.ToString();
            this.idcuentaa = idCuenta.ToString();
        }

        private async void btnDirecta_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransferenciaDirecta(idcuenta.Text,idMonto.Text));
        }

        private async void btnInterbancaria_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransferenciaInterbancaria(this.montoo,this.idcuentaa));
        }
    }
}
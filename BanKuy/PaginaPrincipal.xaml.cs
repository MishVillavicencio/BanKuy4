using BanKuy.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BanKuy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipal : ContentPage
    {
        private const string url = "https://apibankuy-production.up.railway.app/cuentas";
        private readonly HttpClient client = new HttpClient();
        public int idCliente = -1;
       public List<login> datos;
        public string idcuetna;
        public PaginaPrincipal( string idCuentaa)
        {
        InitializeComponent();
            this.idcuetna = idCuentaa;
            Get(idCuentaa);
        }
        public async void Get(string idcliente) {

            try
            {
                string Uri = "https://apibankuy-production.up.railway.app/cuentas/{0}";
                var uri = new Uri(string.Format(Uri,idcliente ));
                var content = await client.GetStringAsync(uri);
                List<datosInicio> post = JsonConvert.DeserializeObject<List<datosInicio>>(content);
                nombreCliente.Text = post[0].nombre.ToString();
                monto.Text = post[0].monto.ToString() ;
                idCuenta.Text = post[0].idCuenta.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }



        private async void btnPerfil_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BanKuy.Perfil(this.idcuetna));
        }

        private async void btnTransferencia_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BanKuy.Transferencia(idCuenta.Text,monto.Text));
        }

        private async void btnServicios_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BanKuy.Servicios());
        }

        private async void btnMovimientos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BanKuy.Movimientos(idCuenta.Text));
        }

        private async void btnCuenta_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BanKuy.Cuenta());
        }

    }
}
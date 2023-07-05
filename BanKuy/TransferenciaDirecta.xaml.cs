using BanKuy.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BanKuy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransferenciaDirecta : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        public double Montoo;
        public TransferenciaDirecta(string idCuenta,string monto)
        {
            InitializeComponent();
            idcuenta.Text = idCuenta.ToString();
            this.Montoo = double.Parse(monto);
        }

        private async void btnContinuar_Clicked(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtMonto.Text))
            {
                await DisplayAlert("Error", "No ha ingresado una cantidad", "Ok");
                return;
            }

            double Monto = double.Parse(txtMonto.Text);

            if (Monto>this.Montoo) 
            {
                await DisplayAlert("Error", "Ha ingresado una cantidad superior a la que tiene en su cuenta", "Ok");
                return;
            }

            await Navigation.PushAsync(new ConfirmarTransferencia(idcuenta.Text,txtNcuenta.Text,txtMonto.Text,"BanCuy",1));
        }

        private async void btnValidar_Clicked(object sender, EventArgs e)
        {







            if (string.IsNullOrEmpty(txtNcuenta.Text)) 
            {
                cuentaVerificada.Text = "Ingrese un valor por favor";
                btnContinuar.IsEnabled = false;



            }
            else if (txtNcuenta.Text!=idcuenta.Text) 
            
            {
                string Uri = "https://apibankuy-production.up.railway.app/verificarCuenta/{0}";
                var uri = new Uri(string.Format(Uri, txtNcuenta.Text.ToString()));
                var content = await client.GetStringAsync(uri);
                List<verificarCuenta> post = JsonConvert.DeserializeObject<List<verificarCuenta>>(content);

                if (content == "[]")
                {
                    cuentaVerificada.Text = "Cuenta no encontrada ingrese de nuevo";
                    btnContinuar.IsEnabled = false;

                }



                else
                {
                    cuentaVerificada.Text = post[0].nombre + " " + post[0].primerApellido;
                    btnContinuar.IsEnabled = true;
                }
            }
            else
            {
                await DisplayAlert("Error", "Cuentas iguales", "Ok");
                btnContinuar.IsEnabled = false;


            }


        }
    }
}
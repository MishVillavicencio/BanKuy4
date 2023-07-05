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
    public partial class Movimientos : ContentPage
    {
        private const string url = "https://apibankuy-production.up.railway.app/cuentas";
        public readonly HttpClient client = new HttpClient();
        public ObservableCollection<transaccionesHistorial> _post;

        public int idCliente = -1;

        public string idCuentaa;
        public Movimientos(string idCuenta)
        {
            InitializeComponent();
            this.idCuentaa = idCuenta;
            



         }

        

        private async void Button_Clicked(object sender, EventArgs e)
        {

            try
            {

                string Uri = "https://apibankuy-production.up.railway.app/transacciones/{0}/{1}";
                var uri = new Uri(string.Format(Uri, this.idCuentaa, "entrada"));
                var content = await client.GetStringAsync(uri);

                List<transaccionesHistorial> post = JsonConvert.DeserializeObject<List<transaccionesHistorial>>(content);

                _post = new ObservableCollection<transaccionesHistorial>(post);
                lstLiatadoEstudiantes.ItemsSource = _post;
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
           
        }

        private  async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {

                string Uri = "https://apibankuy-production.up.railway.app/transacciones/{0}/{1}";
                var uri = new Uri(string.Format(Uri, this.idCuentaa, "salida"));
                var content = await client.GetStringAsync(uri);

                List<transaccionesHistorial> post = JsonConvert.DeserializeObject<List<transaccionesHistorial>>(content);

                _post = new ObservableCollection<transaccionesHistorial>(post);
                lstLiatadoEstudiantes.ItemsSource = _post;
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
    }
    }

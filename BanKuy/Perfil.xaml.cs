using BanKuy.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace BanKuy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        public Perfil(string  idcuenta)
        {
            InitializeComponent();
            
            Get(idcuenta);
        }
        public async void Get(string idcliente)
        {
            try
            {
                string Uri = "https://apibankuy-production.up.railway.app/perfil/{0}";
                var uri = new Uri(string.Format(Uri, idcliente));
                var content = await client.GetStringAsync(uri);
                List<perfil> post = JsonConvert.DeserializeObject<List<perfil>>(content);
                Nombre.Text=post[0].nombre.ToString();
                correo.Text = post[0].correoElectronico.ToString();
                cedula.Text = post[0].cedula.ToString();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}
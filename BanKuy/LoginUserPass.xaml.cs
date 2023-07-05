using BanKuy.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BanKuy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUserPass : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        
        public LoginUserPass()
        {
            InitializeComponent();

            txtCorreo.Text = Preferences.Get("NomberGuardado", "");
            txtCedula.Text = Preferences.Get("contraGuardado", "");
            recordar.IsToggled = Preferences.Get("recordarGurdado", false);

        }
        private async void btnIngresarUser_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtCorreo.Text) && !string.IsNullOrEmpty(txtCedula.Text))
            {
                string Uri = "https://apibankuy-production.up.railway.app/login/{0}/{1}";
                var uri = new Uri(string.Format(Uri, txtCorreo.Text.ToString(), txtCedula.Text.ToString()));
                var content = await client.GetStringAsync(uri);
              
                List<login> post = JsonConvert.DeserializeObject<List<login>>(content);
                if (content == "[{}]")
                {
                    await DisplayAlert("Error", "Correo o contraseña incorrecta", "ok");
                }
                else if (content == "")
                {
                    await DisplayAlert("Alerta", "Cuenta Inactiva", "Ok");
                }
                else
                {
                    await Navigation.PushAsync(new PaginaPrincipal(post[0].idCliente.ToString()));
                }
            }
            else
            {
                await DisplayAlert("Error", "No ha ingresado ningun dato", "Ok");
            }
        }

        private void recordar_Toggled(object sender, ToggledEventArgs e)
        {
            if (recordar.IsToggled == true)
            {
                Preferences.Set("NomberGuardado", txtCorreo.Text);
                Preferences.Set("contraGuardado", txtCedula.Text);
                Preferences.Set("recordarGurdado", recordar.IsToggled);
                recordar.ThumbColor = Color.Blue;
                recordar.OnColor = Color.SkyBlue;
            }
            else
            {
                Preferences.Remove("NomberGuardado");
                Preferences.Remove("contraGuardado");
                Preferences.Remove("recordarGurdado");
                recordar.ThumbColor = Color.Gray;

            }
        }

        
    }
}
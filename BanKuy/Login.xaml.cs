using BanKuy.Modelo;
using Newtonsoft.Json;
using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;

namespace BanKuy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Login : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        public string correo, contrasenia;
        public Login()
        {
            InitializeComponent();
            this.correo = Preferences.Get("NomberGuardado", "");
           this.contrasenia = Preferences.Get("contraGuardado", "");
        }

        private async void btnUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginUserPass());
        }

        private async void btnHuella_Clicked(object sender, EventArgs e)
        {
            var result = await CrossFingerprint.Current.IsAvailableAsync(true);

            if (result)
            {

                var auth = await CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration("Alerta", "Toca el sensor"));
                if (auth.Authenticated)
                {

                    string Uri = "https://apibankuy-production.up.railway.app/login/{0}/{1}";
                    var uri = new Uri(string.Format(Uri, this.correo,this.contrasenia));
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
                 await CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration("Alerta", "ERROR"));

                }

            }
            else
            {
                await DisplayAlert("Oops", "Dispositivo no compatible", "ok");
            }

        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroUsuario());
        }
    }
}
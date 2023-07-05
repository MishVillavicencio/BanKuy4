using BanKuy.Modelo;
using Newtonsoft.Json;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
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
    public partial class LoginHuella : ContentPage
    {
        private readonly HttpClient client = new HttpClient();

        public LoginHuella()
        {
            InitializeComponent();
           Resultado.Text=  Preferences.Get("NomberGuardado", "");
           Resultado1.Text=  Preferences.Get("contraGuardado", "");
            
        }

        private  void btnHuella_Clicked(object sender, EventArgs e)
        {
           

        }
    }
}
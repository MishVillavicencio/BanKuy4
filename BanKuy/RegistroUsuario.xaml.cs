using BanKuy.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public partial class RegistroUsuario : ContentPage
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCedula.Text) && !string.IsNullOrEmpty(txtCelular.Text) && !string.IsNullOrEmpty(txtCorreo.Text) &&
               !string.IsNullOrEmpty(txtFechaNacimiento.Text) && !string.IsNullOrEmpty(txtNombre.Text) &&
               !string.IsNullOrEmpty(txtPrimerApellido.Text) && !string.IsNullOrEmpty(txtSegundoApellido.Text))
            {
                ingresoUsuario ingresoUsuario = new ingresoUsuario
                {
                    nombre = txtNombre.Text,
                    primerApellido = txtPrimerApellido.Text,
                    segundoApellido = txtSegundoApellido.Text,
                    fechaNacimiento = txtFechaNacimiento.Text,
                    celular = txtCelular.Text,
                    cedula = txtCedula.Text,
                    correoElectronico = txtCorreo.Text
                };
                Uri URL = new Uri("https://apibankuy-production.up.railway.app/cuentas");
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(ingresoUsuario);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(URL, contentJson);

               
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    await DisplayAlert("Correcto", "Usuario: " + txtCorreo.Text + "Contraseña: " + txtCedula.Text, "Ok");

                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    await DisplayAlert("Error", "Correo electronico ya registrado", "Ok");
                }

            }
            else
            {
                await DisplayAlert("Erro", "Algun campo esta vacio verifique por favor", "Ok");
            }

        }
    }
}
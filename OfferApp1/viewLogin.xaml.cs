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

namespace OfferApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewLogin : ContentPage
    {
        private const string Url = "http://192.168.100.245/offerApp/postUsuario.php";
        private readonly HttpClient client = new HttpClient();
        public viewLogin()
        {
            InitializeComponent();
        }

        private async void btnAbrir_Clicked(object sender, EventArgs e)
        {
            //almacenar los datos en variables           
            string usuario = txtCorreo.Text;
            string password = txtPassword.Text;

            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                var response = cliente.UploadValues(Url+ "?EMAIL="+usuario+ "&PASSWORD="+password, "POST", parametros);
                


                if (txtCorreo.Text == "es" && txtPassword.Text == "1234")
                {
                    //accion navegar a ventana dos
                    await Navigation.PushAsync(new viewEmpresa());
                    //ALERTA O MENSAJE QUE SE VISUALIZA
                    DisplayAlert("BIENVENIDO", usuario, "OK");
                }

                else if (txtCorreo.Text != "es")
                {
                    await Navigation.PushAsync(new viewCatalogo());
                }
                else if (txtPassword.Text != "1234")
                {
                    await Navigation.PushAsync(new viewCatalogo());
                }

            }
            catch (Exception ex)
            {
                //cargamos la excepción
                await DisplayAlert("ERROR Usuario o Contrasena dato Incorrecto", ex.Message, "OK");
            }
        }

        private async void btnRegistrarse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new viewRegistro());
        }
    }
}
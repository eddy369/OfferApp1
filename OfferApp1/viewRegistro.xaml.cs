using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfferApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewRegistro : ContentPage
    {
        public viewRegistro()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                int rol = 0;
                WebClient cliente = new WebClient();
               
                
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("EMAIL", txtCorreo.Text);
                parametros.Add("PASSWORD", txtPassword.Text);

                cliente.UploadValues("http://192.168.100.245/offerApp/postUsuario.php", "POST", parametros);

                await DisplayAlert("alerta", "Usuario registrado", "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", ex.Message, "ok");
            }
        }

        private async void btnSalir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
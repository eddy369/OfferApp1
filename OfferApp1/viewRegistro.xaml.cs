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

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("EMAIL", txtCorreo.Text);
                parametros.Add("PASSWORD", txtPassword.Text);

                cliente.UploadValues("http://192.168.100.245/moviles/post.php", "POST", parametros);

                DisplayAlert("alerta", "ingreso correcto", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("alerta", ex.Message, "ok");
            }
        }

        private async void btnSalir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
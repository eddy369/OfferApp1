using Plugin.Media;
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
    public partial class viewEmpresa : ContentPage
    {
        public viewEmpresa()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                
                WebClient cliente = new WebClient();                

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("ID_USUARIO", "1");
                parametros.Add("NOMBRE", txtNombreComercial.Text);
                parametros.Add("RAZON_SOCIAL", txtNombre.Text);
                parametros.Add("DIRECCION", txtDireccion.Text);
                parametros.Add("TELEFONO", txtTelefono.Text);
                parametros.Add("CIUDAD", txtCiudad.Text);
                parametros.Add("EMAIL_EMPRESA", txtCorreo.Text);
                

                cliente.UploadValues("http://192.168.100.245/offerApp/postEmpresa.php", "POST", parametros);

                await DisplayAlert("alerta", "Empresa registrada", "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", ex.Message, "ok");
            }
        }

        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new viewCargarArchivo());
        }

        private void btnSeleccionarLogo_Clicked(object sender, EventArgs e)
        {

        }
    }
}
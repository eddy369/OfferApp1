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
    public partial class ActualizarEmpresa : ContentPage
    {
        public ActualizarEmpresa(int id, int u, string n, string t, string d, string r, string e, string c, string l)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            txtUsuario.Text = u.ToString();
            txtNombre.Text = n;
            txtTelefono.Text = t;
            txtDireccion.Text = d;
            txtRazon.Text = r;
            txtEmail.Text = e;
            txtCiudad.Text = c;
            txtLogueado.Text = l;
        }

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                cliente.UploadValues("http://192.168.100.245/offerApp/postEmpresa.php?ID_EMPRESA=" + txtId.Text +
                    "&ID_USUARIO=" + txtUsuario.Text + "&NOMBRE=" + txtNombre.Text + "&TELEFONO=" + txtTelefono.Text+ "&DIRECCION="+txtDireccion.Text+ "&RAZON_SOCIAL="+txtRazon.Text+"&EMAIL_EMPRESA="+txtEmail.Text+"&CIUDAD="+txtCiudad.Text, "PUT", parametros);

                await DisplayAlert("alerta", "Datos actualizados", "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", ex.Message, "ok");
            }
        }

        private async void btnregresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetalleEmpresa(Convert.ToInt32(txtLogueado.Text)));
        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ActualizarProductos : ContentPage
    {
        
        public ActualizarProductos(int id, int em, string code, string nom, string pvp, string desc)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            txtEmpresa.Text = em.ToString();
            txtCodigo.Text = code;
            txtNombre.Text = nom;
            txtPrecio.Text = pvp;
            txtDescripcion.Text = desc;
        }

        private void btnSeleccionarImagen_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

               
                cliente.UploadValues("http://192.168.100.245/offerApp/postProducto.php?ID_PRODUCTO=" + txtId.Text +
                "&ID_EMPRESA=" + txtEmpresa.Text + "&CODIGO=" + txtCodigo.Text + "&NOMBRE_PRODUCTO=" + txtNombre.Text + "&PVP=" + txtPrecio.Text + "&DESCRIPCION=" + txtDescripcion.Text, "PUT", parametros);

                await DisplayAlert("alerta", "Datos actualizados", "ok");             

                
            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", ex.Message, "ok");
            }

        }

        private async void btnSalir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetalleProductos(Convert.ToInt32(txtEmpresa.Text)));
        }
    }
}
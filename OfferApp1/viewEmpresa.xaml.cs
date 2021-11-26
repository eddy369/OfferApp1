using Newtonsoft.Json;
using Plugin.Media;
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
    public partial class viewEmpresa : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<OfferApp1.DatosEmpresa> _post;
        public viewEmpresa(int id)
        {
            InitializeComponent();
            txtUsuario.Text = id.ToString();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                
                WebClient cliente = new WebClient();                

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("ID_USUARIO", txtUsuario.Text);
                parametros.Add("NOMBRE", txtNombreComercial.Text);
                parametros.Add("RAZON_SOCIAL", txtNombre.Text);
                parametros.Add("DIRECCION", txtDireccion.Text);
                parametros.Add("TELEFONO", txtTelefono.Text);
                parametros.Add("CIUDAD", txtCiudad.Text);
                parametros.Add("EMAIL_EMPRESA", txtCorreo.Text);
                parametros.Add("LOGO", "prueba.jpg");

                var content = await client.GetStringAsync("http://192.168.100.245/offerApp/postEmpresa.php?ID_USUARIO="+txtUsuario.Text);
                List<OfferApp1.DatosEmpresa> post = JsonConvert.DeserializeObject<List<OfferApp1.DatosEmpresa>>(content);
                _post = new ObservableCollection<OfferApp1.DatosEmpresa>(post);

                var usuario = 0;
                var valida = "no";
                for (int i = 0; i < _post.Count(); i++)
                {
                    usuario = _post.ElementAt(i).ID_USUARIO;

                    if (usuario == Convert.ToInt32(txtUsuario.Text))
                    {
                        valida = "si";
                    }

                }

                if (valida == "si")
                {
                    await DisplayAlert("alerta", "El usuario ya posee una empresa", "OK");
                }
                else
                {
                    cliente.UploadValues("http://192.168.100.245/offerApp/postEmpresa.php", "POST", parametros);

                    await DisplayAlert("alerta", "Empresa registrada", "ok");
                }


                
            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", ex.Message, "ok");
            }
        }
                
        private async void btnSeleccionarLogo_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos not Supported", ":( Permission not granted to photos.", "ok");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            { 
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });

            if (file == null)
                return;

            Imagen.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
            
        }

        private async void btnSalir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetalleEmpresa(Convert.ToInt32(txtUsuario.Text)));
        }
    }
}
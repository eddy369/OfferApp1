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
    public partial class viewRegistro : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<OfferApp1.DatosUsuario> _post;
        public viewRegistro()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var rol = "";
                WebClient cliente = new WebClient();
                if (rbEmpresa.IsChecked == true){
                    rol = rbEmpresa.Value.ToString();
                }
                else
                {
                    rol = "3";
                }
                
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("EMAIL", txtCorreo.Text);
                parametros.Add("PASSWORD", txtPassword.Text);
                parametros.Add("ID_ROLES", rol);


                var content = await client.GetStringAsync("http://192.168.100.245/offerApp/postUsuario.php");
                List<OfferApp1.DatosUsuario> post = JsonConvert.DeserializeObject<List<OfferApp1.DatosUsuario>>(content);
                _post = new ObservableCollection<OfferApp1.DatosUsuario>(post);

                var email = "";
                var valida = "no";
                for (int i = 0; i < _post.Count(); i++)
                {
                    email = _post.ElementAt(i).EMAIL;

                    if (email == txtCorreo.Text)
                    {
                        valida = "si";                        
                    }

                }

                if (valida == "si")
                {
                    await DisplayAlert("alerta", "El correo ingresado ya existe", "OK");
                }
                else
                {
                    cliente.UploadValues("http://192.168.100.245/offerApp/postUsuario.php", "POST", parametros);

                    await DisplayAlert("alerta", "Usuario registrado", "ok");
                }


            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", ex.Message, "ok");
            }
        }

        private async void btnSalir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new viewLogin());
        }
    }
}
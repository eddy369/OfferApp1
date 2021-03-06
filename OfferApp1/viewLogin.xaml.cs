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
    public partial class viewLogin : ContentPage
    {
        private const string Url = "http://192.168.100.245/offerApp/postUsuario.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<OfferApp1.DatosUsuario> _post;
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
               

                var content = await client.GetStringAsync(Url);
                List<OfferApp1.DatosUsuario> post = JsonConvert.DeserializeObject<List<OfferApp1.DatosUsuario>>(content);
                _post = new ObservableCollection<OfferApp1.DatosUsuario>(post);
                DatosUsuario data = new DatosUsuario {EMAIL=usuario,PASSWORD=password};

                var email = "";
                var pass = "";
                int id = 0;
                int rol = 0;
                var ok = "no";
                for (int i=0; i< _post.Count(); i++)
                {
                    email = _post.ElementAt(i).EMAIL;
                    pass = _post.ElementAt(i).PASSWORD;
                    id = _post.ElementAt(i).ID_USUARIO;
                    rol = _post.ElementAt(i).ID_ROLES;

                    if (email == usuario && pass == password)
                    {
                       if (rol==1 || rol == 2)
                        {
                            await Navigation.PushAsync(new DetalleEmpresa(id));
                           // await Navigation.PushAsync(new viewEmpresa(id));
                        }
                        else
                        {
                            await Navigation.PushAsync(new viewCatalogo(1));
                        }
                        ok = "si";
                        await DisplayAlert("BIENVENIDO", email, "OK");
                    }
                    
                    
                }

                if (ok == "no")
                {
                    await DisplayAlert("ERROR", "usuario o contrasenia incorrectos", "OK");
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
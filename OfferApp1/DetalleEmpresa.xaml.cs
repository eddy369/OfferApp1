using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfferApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleEmpresa : ContentPage
    {
        private const string Url = "http://192.168.100.245/offerApp/postEmpresa.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<OfferApp1.DatosEmpresa> _post;
        public DetalleEmpresa(int id)
        {
            InitializeComponent();
            get(id);
            txtLogueado.Text = id.ToString();
        }

        private async void get(int u)
        {
            try
            {
                var content = await client.GetStringAsync(Url+"?ID_USUARIO="+u);
                List<OfferApp1.DatosEmpresa> post = JsonConvert.DeserializeObject<List<OfferApp1.DatosEmpresa>>(content);
                _post = new ObservableCollection<OfferApp1.DatosEmpresa>(post);

               
                    MyListEmpresa.ItemsSource = _post;
                          

            }
            catch (Exception ex)
            {
                await DisplayAlert("error", ex.Message, "OK");
            }


        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                DatosEmpresa c = MyListEmpresa.SelectedItem as DatosEmpresa;
                int id = c.ID_EMPRESA;
                int usu = c.ID_USUARIO;
                string nombre = c.NOMBRE;
                string telefono = c.TELEFONO;
                string direccion = c.DIRECCION;
                string razon = c.RAZON_SOCIAL;
                string email = c.EMAIL_EMPRESA;
                string ciudad = c.CIUDAD;
                string log = txtLogueado.Text;
                await Navigation.PushAsync(new ActualizarEmpresa(id, usu, nombre, telefono, direccion, razon, email, ciudad,log));
            }
            catch(Exception ex)
            {
                await DisplayAlert("Alerta", "Seleccione el registro que desea actualizar", "ok");
            }
            
        }

        private void btnProductos_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnNuevo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new viewEmpresa(Convert.ToInt32(txtLogueado.Text)));
        }
    }
}
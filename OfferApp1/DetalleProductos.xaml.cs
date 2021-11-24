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
    public partial class DetalleProductos : ContentPage
    {
        private const string Url = "http://192.168.100.245/offerApp/postProducto.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<OfferApp1.DatosProducto> _post;
        public DetalleProductos(int id)
        {
            InitializeComponent();
            get(id);
            txtEmpresa.Text = id.ToString();
        }

        private async void get(int id)
        {
            try
            {
                var content = await client.GetStringAsync(Url + "?ID_EMPRESA=" + id);
                List<OfferApp1.DatosProducto> post = JsonConvert.DeserializeObject<List<OfferApp1.DatosProducto>>(content);
                _post = new ObservableCollection<OfferApp1.DatosProducto>(post);

                MyListProductos.ItemsSource = _post;

            }
            catch (Exception ex)
            {
                await DisplayAlert("error", ex.Message, "OK");
            }

        }

        private void btnNuevo_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                DatosProducto c = MyListProductos.SelectedItem as DatosProducto;
                int id = c.ID_PRODUCTO;
                int empresa = c.ID_EMPRESA;
                string codigo = c.CODIGO;
                string nombre = c.NOMBRE_PRODUCTO;
                string precio = c.PVP;
                string descripcion = c.DESCRIPCION;
                await Navigation.PushAsync(new ActualizarProductos(id, empresa, codigo, nombre, precio, descripcion));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Seleccione el producto que desea actualizar", "ok");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                DatosProducto c = MyListProductos.SelectedItem as DatosProducto;
                _post.Remove(c);
                var parametros = new System.Collections.Specialized.NameValueCollection();

                cliente.UploadValues("http://192.168.100.245/offerApp/postProducto.php?ID_PRODUCTO=" + c.ID_PRODUCTO, "DELETE", parametros);

                DisplayAlert("alerta", "Se elimino el registro " + c.ID_PRODUCTO, "ok");

            }
            catch (Exception ex)
            {
                DisplayAlert("alerta", ex.Message, "ok");
            }
        }
    }
}
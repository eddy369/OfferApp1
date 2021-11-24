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
    public partial class Catalogo : ContentPage
    {
        private const string Url = "http://192.168.100.245/offerApp/postProducto.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<OfferApp1.DatosProducto> _post;
        public Catalogo(int id, string n)
        {
            InitializeComponent();
            get(id);
            txtEmpresa.Text = id.ToString();
            txtName.Text = n;
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

        private async void btnDetalle_Clicked(object sender, EventArgs e)
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
                string name = txtName.Text;
                await Navigation.PushAsync(new Producto(id, empresa, codigo, nombre, precio, descripcion,name));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Seleccione un producto", "ok");
            }


        }
    }
}
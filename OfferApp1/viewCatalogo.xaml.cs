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
    public partial class viewCatalogo : ContentPage
    {
        private const string Url = "http://192.168.100.245/offerApp/postEmpresa.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<OfferApp1.DatosEmpresa> _post;
        public viewCatalogo(int u)
        {
            InitializeComponent();
            get(u);
        }

        private async void get(int u)
        {
            try
            {
                var content = await client.GetStringAsync(Url+"?ID_USUARIO="+ u);
                List<OfferApp1.DatosEmpresa> post = JsonConvert.DeserializeObject<List<OfferApp1.DatosEmpresa>>(content);
                _post = new ObservableCollection<OfferApp1.DatosEmpresa>(post);

                MyListView.ItemsSource = _post;

            }
            catch(Exception ex)
            {
               await DisplayAlert("error", ex.Message, "OK");
            }
            

        }

        private async void btnVer_Clicked(object sender, EventArgs e)
        {
            try
            {
                DatosEmpresa c = MyListView.SelectedItem as DatosEmpresa;
                int id = c.ID_EMPRESA;
                string name = c.NOMBRE;
                await Navigation.PushAsync(new Catalogo(id,name));
            }
            catch
            {
                await DisplayAlert("Alerta", "Seleccione una Empresa", "ok");
            }
            
        }
    }
}
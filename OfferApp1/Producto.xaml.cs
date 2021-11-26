using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfferApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Producto : ContentPage
    {
        public Producto(int id, int em, string code, string nom, string pvp, string desc, string n, string img)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            txtEmpresa.Text = em.ToString();
            lblNombre.Text = nom;
            lblPVP.Text = pvp;
            lblDescrip.Text = desc;
            lblEmpresa.Text = n;
            imagen.Source = img;
        }

        private async void btnCerrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Catalogo(Convert.ToInt32(txtEmpresa.Text), lblNombre.Text));
        }        

        private async void btnFacebook_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var url = button.ClassId;

            await Browser.OpenAsync(url + txtEmpresa.Text);
           
        }

        private async void btnWhatsapp_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var url = button.ClassId;

            await Browser.OpenAsync(url);
        }
    }
}
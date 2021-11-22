using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OfferApp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewLogin : ContentPage
    {
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

                if (txtCorreo.Text == "es" && txtPassword.Text == "1234")
                {
                    //accion navegar a ventana dos
                    await Navigation.PushAsync(new viewEmpresa());
                    //ALERTA O MENSAJE QUE SE VISUALIZA
                    DisplayAlert("BIENVENIDO", usuario, "OK");
                }

                else if (txtCorreo.Text != "es")
                {
                    await Navigation.PushAsync(new viewCatalogo());
                }
                else if (txtPassword.Text != "1234")
                {
                    await Navigation.PushAsync(new viewCatalogo());
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OfferApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
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
                    await Navigation.PushAsync(null);
                }
                else if (txtPassword.Text != "1234")
                {
                    await Navigation.PushAsync(null);
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

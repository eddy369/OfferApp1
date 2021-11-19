﻿using System;
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
            string usuario = txtUsuario.Text;
            string password = txtContrasena.Text;

            try
            {

                if (txtUsuario.Text == "es" && txtContrasena.Text == "1234")
                {
                    //accion navegar a ventana dos
                    await Navigation.PushAsync(new viewEmpresa());
                    //ALERTA O MENSAJE QUE SE VISUALIZA
                    DisplayAlert("BIENVENIDO", usuario, "OK");
                }

                else if (txtUsuario.Text != "es")
                {
                    await Navigation.PushAsync(null);
                }
                else if (txtContrasena.Text != "1234")
                {
                    await Navigation.PushAsync(null);
                }

            }
            catch (Exception ex)
            {
                //cargamos la excepción
                DisplayAlert("ERROR Usuario o Contrasena dato Incorrecto", ex.Message, "OK");
            }
        }
    }
}
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
    public partial class Producto : ContentPage
    {
        public Producto(int id, int em, string code, string nom, string pvp, string desc, string n)
        {
            InitializeComponent();
            txtId.Text = id.ToString();
            txtEmpresa.Text = em.ToString();
            lblNombre.Text = nom;
            lblPVP.Text = pvp;
            lblDescrip.Text = desc;
            lblEmpresa.Text = n;
        }
    }
}
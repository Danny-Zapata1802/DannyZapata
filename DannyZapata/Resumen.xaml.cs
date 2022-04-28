using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DannyZapata
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resumen : ContentPage
    {
        public Resumen(string usuario, string nombre, string totalPagar)
        {
            InitializeComponent();
            txtUsuario.Text = usuario;
            txtNombre.Text = nombre;
            txtTotalPagar.Text = totalPagar;
        }
    }
}
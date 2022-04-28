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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;
                if (usuario == "danny2022" && password == "uisrael2022")
                {
                    await Navigation.PushAsync(new Registro(usuario, password));
                }
                else { await DisplayAlert("Alert", "Usuario y/o contraseña Incorrectos", "cerrar"); }

        }
    }
}
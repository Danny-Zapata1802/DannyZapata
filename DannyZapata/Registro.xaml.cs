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
    public class NumericValidationBehavior : Behavior<Entry>
    {

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {

            if (!string.IsNullOrWhiteSpace(args.NewTextValue))
            {
                bool isValid = args.NewTextValue.ToCharArray().All(x => char.IsDigit(x)); //Make sure all characters are numbers

                ((Entry)sender).Text = isValid ? args.NewTextValue : args.NewTextValue.Remove(args.NewTextValue.Length - 1);
            }
        }


    }
    public partial class Registro : ContentPage
    {
        public Registro(string usuario, string password)
        {
            InitializeComponent();
            lblUsuario.Text = " Usuario conectado: " + usuario;
            lblUsuario2.Text = usuario;
        }

        private async void btnCalcular_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (txtMontoInicial.Text != "" && txtMontoMensual.Text != "" && txtNombre.Text != "")
                {
                    int costo = 3000;
                    double mInicial = Convert.ToDouble(txtMontoInicial.Text);
                    if (mInicial < costo && mInicial > 0)
                    {

                        if (!txtMontoInicial.Text.ToCharArray().All(Char.IsDigit))
                        {
                            await DisplayAlert("Advertencia", "El formato del monto inicial es incorrecto, solo se aceptan numeros.", "OK");
                        }
                        double calculoInicial = (costo - mInicial) / 5;
                        double calculoFinal = calculoInicial + 150;
                        txtMontoMensual.Text = calculoFinal.ToString();
                        string usuario = lblUsuario2.Text;
                        string nombre = txtNombre.Text;
                        double calculo = mInicial + calculoFinal*(5) ;
                        string totalPagar = calculo.ToString();
                        await Navigation.PushAsync(new Resumen(usuario, nombre, totalPagar));
                    }
                    else
                    {
                        await DisplayAlert("Alert", "Valor no válido", "cerrar");
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "No hay valores ingresados", "cerrar");
                }
                

            }
            catch (Exception)
            {

            }

        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if ( txtMontoInicial.Text != "" && txtMontoMensual.Text != "" && txtNombre.Text != "" )
            {
                
                await DisplayAlert("Success", "Datos Guardados", "OK");
                
            }
            else
            {
                await DisplayAlert("Alert", "No hay valores ingresados", "cerrar");
            }
        }
    }
}
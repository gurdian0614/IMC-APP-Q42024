
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Runtime.CompilerServices;

namespace IMC_APP_Q42024.ViewModels
{
    public partial class ImcViewModel : ObservableObject
    {
        [ObservableProperty]
        private double peso;

        [ObservableProperty]
        private double estatura;

        [ObservableProperty]
        private string resultado;

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private void Calcular()
        {
            double imc = 0;

            try
            {
                if (Peso <= 0)
                {
                    Alerta("ADVERTENCIA", "Valor del peso no válido");
                }
                else if (Estatura <= 0)
                {
                    Alerta("ADVERTENCIA", "Valor de la estatura no válida");
                }
                else
                {
                    imc = Peso / (Estatura * Estatura);
                    Resultado = $"{Math.Round(imc, 1).ToString()} - {mensajeImc(imc)}";
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        [RelayCommand]
        private void Limpiar()
        {
            Peso = 0;
            Estatura = 0;
            Resultado = "";
        }

        private string mensajeImc(double imc)
        {
            string mensaje = "";

            if (imc < 18.5)
            {
                mensaje = "Bajo peso";
            } else if(imc >= 18.5 && imc <= 24.9)
            {
                mensaje = "Peso normal";
            }
            else if (imc >= 25 && imc <= 29.9)
            {
                mensaje = "Sobrepeso";
            } else
            {
                mensaje = "Obesidad";
            }

            return mensaje;
        }
    }
}

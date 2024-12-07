
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
        private double imc;

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private void Calcular()
        {
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
                    Imc = Peso / (Estatura * Estatura);
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
            Imc = 0;
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImcApp.Maui.Models;

namespace ImcApp.Maui.ViewModels
{
    //Una clase parcial significa que solo sea una parte de ella
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _peso;
        [ObservableProperty]
        private string _estatura;
        [ObservableProperty]
        private string _imc;
        [ObservableProperty]
        private string _situacionNutricional;

        public MainViewModel() // Constructor
        {
            Limpiar();
        }

        [RelayCommand]
        private void Limpiar()
        {
            Peso = string.Empty;
            Estatura = string.Empty;
            Imc = string.Empty;
            SituacionNutricional = string.Empty;
        }

        [RelayCommand]
        public void Calcular()
        {
            // Parse convierte su argumento en decimal, pero me puede arrojar una excepcion
            decimal estatura;
            decimal peso;

            // TryParse me devuelve falso o verdadero
            bool pesoEsValido = decimal.TryParse(Peso, out peso);
            bool estaturaEsValida = decimal.TryParse(Estatura, out estatura);

            if (pesoEsValido && estaturaEsValida)
            {
                decimal imc = CalculadoraDeIndiceDeMasaCorporal.IndiceDeMasaCorporal(peso, estatura);
                Imc = imc.ToString("F4");
                SituacionNutricional = CalculadoraDeIndiceDeMasaCorporal.SituacionNutricional(imc);
            }
        }
    }
}

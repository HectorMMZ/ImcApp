using ImcApp.Maui.Models;
using System.ComponentModel;
using System.Windows.Input;

namespace ImcApp.Maui.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _peso;
        private string _estatura;
        private string _imc;
        private string _situacionNutricional;
        public string Peso
        {
            get => _peso;
            set
            {
                if (_peso != value)
                {
                    _peso = value;
                    OnPropertyChanged(nameof(Peso)); // Esto sera un aviso para que la interfaz de usuario cambie
                }
            }
        }
        public string Estatura
        {
            get => _estatura;
            set
            {
                if (_estatura != value)
                {
                    _estatura = value;
                    OnPropertyChanged(nameof(Estatura));
                }
            }
        }
        public string Imc
        {
            get => _imc;
            set
            {
                if (_imc != value)
                {
                    _imc = value;
                    OnPropertyChanged(nameof(Imc));
                }
            }
        }
        public string SituacionNutricional
        {
            get => _situacionNutricional;
            set
            {
                if (_situacionNutricional != value)
                {
                    _situacionNutricional = value;
                    OnPropertyChanged(nameof(SituacionNutricional));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand CalcularCommand { get; private set; }
        public ICommand LimpiarCommand { get; private set; }

        public MainViewModel() // Constructor
        {
            LimpiarValores();
            CalcularCommand = new Command(Calcular);
            LimpiarCommand = new Command(LimpiarValores);
        }

        private void LimpiarValores()
        {
            Peso = string.Empty;
            Estatura = string.Empty;
            Imc = string.Empty;
            SituacionNutricional = string.Empty;
        }

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

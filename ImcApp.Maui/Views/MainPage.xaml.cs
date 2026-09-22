using ImcApp.Maui.Models;

namespace ImcApp.Maui.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        LimpiarValores();
	}

    private void OnCalcularButtonClicked(object sender, EventArgs e)
    {
        // Parse convierte su argumento en decimal, pero me puede arrojar una excepcion
        decimal estatura;
        decimal peso;

        // TryParse me devuelve falso o verdadero
        bool pesoEsValido = decimal.TryParse(PesoLabel.Text, out peso);
        bool estaturaEsValida = decimal.TryParse(EstaturaLabel.Text, out estatura);
        if (pesoEsValido && estaturaEsValida)
        {
            decimal imc = CalculadoraDeIndiceDeMasaCorporal.IndiceDeMasaCorporal(peso, estatura);
            ImcLabel.Text = imc.ToString("F4");
            SituacionNutricionalLabel.Text = CalculadoraDeIndiceDeMasaCorporal.SituacionNutricional(imc);
        }
    }

    private void OnLimpiarButtonClicked(object sender, EventArgs e)
    {
        // Para limpiar los datos
        LimpiarValores();
    }

    private void LimpiarValores()
    {
        PesoLabel.Text = string.Empty;
        EstaturaLabel.Text = string.Empty;
        ImcLabel.Text = string.Empty;
        SituacionNutricionalLabel.Text = string.Empty;
    }
}
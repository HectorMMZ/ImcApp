using ImcApp.Maui.ViewModels;

namespace ImcApp.Maui.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
        InitializeComponent();
		BindingContext = new MainViewModel();
	}
}